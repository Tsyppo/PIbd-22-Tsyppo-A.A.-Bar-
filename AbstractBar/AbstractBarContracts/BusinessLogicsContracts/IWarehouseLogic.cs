using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;
using System.Collections.Generic;


namespace AbstractBarContracts.BusinessLogicsContracts
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);

        void CreateOrUpdate(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);

        void AddComponent(WarehouseBindingModel model, int componentId, int count);
    }
}
