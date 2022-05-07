using System.Collections.Generic;
using AbstractBarContracts.ViewModels;

namespace AbstractBarBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfoWarehouses : ExcelInfo
    {
        public List<ReportWarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}
