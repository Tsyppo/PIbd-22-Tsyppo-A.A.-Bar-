using System.Collections.Generic;
using AbstractBarContracts.ViewModels;

namespace AbstractBarBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfoTotalOrders : PdfInfo
    {
        public List<ReportTotalOrdersViewModel> TotalOrders { get; set; }
    }
}
