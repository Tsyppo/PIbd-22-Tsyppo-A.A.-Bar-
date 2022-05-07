﻿using System;
using System.Collections.Generic;
using System.Linq;
using AbstractBarBusinessLogic.OfficePackage;
using AbstractBarBusinessLogic.OfficePackage.HelperModels;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;

namespace AbstractBarBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;

        private readonly ICocktailStorage _cocktailStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IWarehouseStorage _warehouseStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(ICocktailStorage cocktailStorage, IComponentStorage
        componentStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
        AbstractSaveToPdf saveToPdf)
        {
            _cocktailStorage = cocktailStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка компонентов с указанием, в каких изделиях используются
        public List<ReportCocktailComponentViewModel> GetCocktailComponent()
        {
            var Cocktails = _cocktailStorage.GetFullList();
            var list = new List<ReportCocktailComponentViewModel>();
            foreach (var Cocktail in Cocktails)
            {
                var record = new ReportCocktailComponentViewModel
                {
                    CocktailName = Cocktail.CocktailName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var Component in Cocktail.CocktailComponents)
                {
                    record.Components.Add(new Tuple<string, int>(Component.Value.Item1, Component.Value.Item2));
                    record.TotalCount += Component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                CocktailName = x.CocktailName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        // Сохранение коктейлей в файл-Word
        public void SaveCocktailsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Cocktails = _cocktailStorage.GetFullList()
            });
        }

        // Сохранение компонентов с указаеним продуктов в файл-Excel
        public void SaveCocktailComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список тканей",
                CocktailComponents = GetCocktailComponent()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public List<ReportWarehouseComponentViewModel> GetWarehouseComponents()
        {
            var Cocktails = _warehouseStorage.GetFullList();
            var list = new List<ReportWarehouseComponentViewModel>();
            foreach (var Cocktail in Cocktails)
            {
                var record = new ReportWarehouseComponentViewModel
                {
                    WarehouseName = Cocktail.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var Component in Cocktail.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(Component.Value.Item1, Component.Value.Item2));
                    record.TotalCount += Component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveWarehouseComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateWarehouseReport(new ExcelInfoWarehouses
            {
                FileName = model.FileName,
                Title = "Список тканей складов",
                WarehouseComponents = GetWarehouseComponents()
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateWarehouseDoc(new WordInfoWarehouses
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }

        public List<ReportTotalOrdersViewModel> GetTotalOrders()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToLongDateString())
                .Select(rec => new ReportTotalOrdersViewModel
                {
                    DateCreate = Convert.ToDateTime(rec.Key),
                    TotalCount = rec.Count(),
                    TotalSum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }

        public void SaveTotalOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocTotalOrders(new PdfInfoTotalOrders
            {
                FileName = model.FileName,
                Title = "Список заказов за весь период",
                TotalOrders = GetTotalOrders()
            });
        }
    }
}
