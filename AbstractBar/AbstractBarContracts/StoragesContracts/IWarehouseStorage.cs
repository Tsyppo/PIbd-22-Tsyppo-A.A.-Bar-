using System.Collections.Generic;
using System.Text;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;

namespace AbstractBarContracts.StoragesContracts
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();
        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);
        WarehouseViewModel GetElement(WarehouseBindingModel model);
        void Insert(WarehouseBindingModel model);
        void Update(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
        bool TakeComponentFromWarehouse(Dictionary<int, (string, int)> Components, int orderCount);
    }
}
