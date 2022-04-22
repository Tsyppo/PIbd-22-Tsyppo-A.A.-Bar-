using System;
using System.Collections.Generic;
using System.Linq;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarFileImplement.Models;

namespace AbstractBarFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;
        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses
                .FirstOrDefault(rec => rec.Id == model.Id || rec.WarehouseName == model.WarehouseName);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Warehouse
            {
                Id = maxId + 1,
                WarehouseComponents = new Dictionary<int, int>()
            };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public bool TakeComponentFromWarehouse(Dictionary<int, (string, int)> Components, int orderCount)
        {
            foreach (var Component in Components)
            {
                int count = source.Warehouses
                    .Where(rec => rec.WarehouseComponents.ContainsKey(Component.Key)).Sum(rec => rec.WarehouseComponents[Component.Key]);
                if (count < Component.Value.Item2 * orderCount)
                {
                    return false;
                }
            }
            foreach (var Component in Components)
            {
                int reqCount = Component.Value.Item2 * orderCount;
                foreach (var warehouse in source.Warehouses)
                {
                    var warehouseComponent = warehouse.WarehouseComponents;
                    if (!warehouseComponent.ContainsKey(Component.Key))
                    {
                        continue;
                    }
                    if (warehouseComponent[Component.Key] > reqCount)
                    {
                        warehouseComponent[Component.Key] -= reqCount;
                        break;
                    }
                    else if (warehouseComponent[Component.Key] <= reqCount)
                    {
                        reqCount -= warehouseComponent[Component.Key];
                        warehouseComponent.Remove(Component.Key);
                    }
                    if (reqCount == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses
               .FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
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
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recGT => recGT.Key, recGT => (source.Components.FirstOrDefault(recC => recC.Id == recGT.Key)?.ComponentName, recGT.Value))
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
            foreach (var Component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(Component.Key))
                {
                    warehouse.WarehouseComponents[Component.Key] = model.WarehouseComponents[Component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(Component.Key, model.WarehouseComponents[Component.Key].Item2);
                }
            }
            return warehouse;
        }
    }
}
