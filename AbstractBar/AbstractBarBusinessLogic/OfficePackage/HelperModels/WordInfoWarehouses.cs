using System.Collections.Generic;
using AbstractBarContracts.ViewModels;

namespace AbstractBarBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfoWarehouses : WordInfo
    {
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
