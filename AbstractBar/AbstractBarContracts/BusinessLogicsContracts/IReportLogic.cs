using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;
using System.Collections.Generic;


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
