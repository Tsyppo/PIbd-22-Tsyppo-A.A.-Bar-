using System;
using System.Collections.Generic;
using System.Linq;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using AbstractBarDatabaseImplement.Models;

namespace AbstractBarDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public void Delete(WarehouseBindingModel model)
        {
            var context = new AbstractBarDatabase();
            var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var context = new AbstractBarDatabase();
            var warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var context = new AbstractBarDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            var context = new AbstractBarDatabase();
            return context.Warehouses
                .Include(rec => rec.WarehouseComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(WarehouseBindingModel model)
        {
            var context = new AbstractBarDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                CreateModel(model, new Warehouse(), context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool TakeComponentFromWarehouse(Dictionary<int, (string, int)> Components, int orderCount)
        {
            var context = new AbstractBarDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var warehouseComponent in Components)
                {
                    int count = warehouseComponent.Value.Item2 * orderCount;
                    IEnumerable<WarehouseComponent> WarehouseComponents = context.WarehouseComponents
                        .Where(warehouse => warehouse.ComponentId == warehouseComponent.Key);
                    foreach (var Component in WarehouseComponents)
                    {
                        if (Component.Count <= count)
                        {
                            count -= Component.Count;
                            context.WarehouseComponents.Remove(Component);
                            context.SaveChanges();
                        }
                        else
                        {
                            Component.Count -= count;
                            context.SaveChanges();
                            count = 0;
                        }
                        if (count == 0)
                        {
                            break;
                        }
                    }
                    if (count != 0)
                    {
                        throw new Exception("Недостаточно тканей для передачи заказа в работу");
                    }
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            var context = new AbstractBarDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }

                CreateModel(model, warehouse, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, AbstractBarDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var WarehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(WarehouseComponents
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateComponent in WarehouseComponents)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }


            foreach (var WarehouseComponent in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = WarehouseComponent.Key,
                    Count = WarehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents
                        .ToDictionary(recWarehouseComponents => recWarehouseComponents.ComponentId,
                         recWarehouseComponents => (recWarehouseComponents.Component?.ComponentName,
                         recWarehouseComponents.Count))
            };
        }
    }
}
