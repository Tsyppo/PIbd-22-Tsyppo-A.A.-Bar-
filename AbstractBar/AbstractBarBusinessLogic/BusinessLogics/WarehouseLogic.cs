using System;
using System.Collections.Generic;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;

namespace AbstractBarBusinessLogic.BusinessLogics
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IWarehouseStorage warehouseStorage;
        private readonly IComponentStorage componentStorage;
        public WarehouseLogic(IWarehouseStorage warehouseStorage, IComponentStorage componentStorage)
        {
            this.warehouseStorage = warehouseStorage;
            this.componentStorage = componentStorage;
        }
        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { warehouseStorage.GetElement(model) };
            }
            return warehouseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = warehouseStorage.GetElement(new WarehouseBindingModel { WarehouseName = model.WarehouseName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                warehouseStorage.Update(model);
            }
            else
            {
                warehouseStorage.Insert(model);
            }
        }
        public void Delete(WarehouseBindingModel model)
        {
            var element = warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            warehouseStorage.Delete(model);
        }
        public void AddComponent(WarehouseBindingModel model, int componentId, int amount)
        {
            var warehouse = warehouseStorage.GetElement(new WarehouseBindingModel { Id = model.Id });
            if (warehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            var component = componentStorage.GetElement(new ComponentBindingModel { Id = componentId });
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (warehouse.WarehouseComponents.ContainsKey(componentId))
            {
                int prevAmount = warehouse.WarehouseComponents[componentId].Item2;
                warehouse.WarehouseComponents[componentId] = (component.ComponentName, prevAmount + amount);
            }
            else
            {
                warehouse.WarehouseComponents.Add(componentId, (component.ComponentName, amount));
            }
            warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePerson = warehouse.ResponsiblePerson,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents
            });
        }
    }
}
