using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;


namespace AbstractBarContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        List<ReportCocktailComponentViewModel> GetCocktailComponent();
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        List<ReportWarehouseComponentViewModel> GetWarehouseComponents();
        List<ReportTotalOrdersViewModel> GetTotalOrders();
        void SaveCocktailsToWordFile(ReportBindingModel model);
        void SaveWarehousesToWordFile(ReportBindingModel model);
        void SaveCocktailComponentToExcelFile(ReportBindingModel model);
        void SaveWarehouseComponentToExcelFile(ReportBindingModel model);
        void SaveOrdersToPdfFile(ReportBindingModel model);
        void SaveTotalOrdersToPdfFile(ReportBindingModel model);
    }
}
