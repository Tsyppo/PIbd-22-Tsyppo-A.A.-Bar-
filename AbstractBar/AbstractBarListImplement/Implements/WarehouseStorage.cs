using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarListImplement.Models;

namespace AbstractBarListImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {

        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id ||
                    warehouse.WarehouseName == model.WarehouseName)
                {
                    return CreateModel(warehouse);
                }
            }
            return null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(warehouse));
                }
            }
            return result;
        }

        public List<WarehouseViewModel> GetFullList()
        {
            var result = new List<WarehouseViewModel>();
            foreach (var Component in source.Warehouses)
            {
                result.Add(CreateModel(Component));
            }
            return result;
        }

        public void Insert(WarehouseBindingModel model)
        {
            var tempWarehouse = new Warehouse { Id = 1, WarehouseComponents = new Dictionary<int, int>() };
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWarehouse));
        }

        public bool TakeComponentFromWarehouse(Dictionary<int, (string, int)> Components, int orderCount)
        {
            throw new NotImplementedException();
        }

        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = null;
            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }
            if (tempWarehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWarehouse);
        }
        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            var warehouseComponents = new Dictionary<int, (string, int)>();
            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string ComponentName = string.Empty;
                foreach (var Component in source.Components)
                {
                    if (warehouseComponent.Key == Component.Id)
                    {
                        ComponentName = Component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (ComponentName, warehouseComponent.Value));
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }

        private Warehouse CreateModel(WarehouseBindingModel model,
            Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePerson = model.ResponsiblePerson;
            warehouse.DateCreate = model.DateCreate;
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] = model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }
    }
}