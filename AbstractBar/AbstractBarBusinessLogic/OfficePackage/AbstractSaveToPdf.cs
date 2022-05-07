using AbstractBarBusinessLogic.OfficePackage.HelperEnums;
using AbstractBarBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;

namespace AbstractBarBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateParagraph(new PdfParagraph
            {
                Text = $"с { info.DateFrom.ToShortDateString() } по { info.DateTo.ToShortDateString() }",
                Style = "Normal"
            });
            CreateTable(new List<string> { "3cm", "6cm", "3cm", "2cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата заказа", "Изделие", "Количество",
                "Сумма", "Статус" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.Orders)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(),
                    order.CocktailName, order.Count.ToString(), order.Sum.ToString(), order.Status.ToString()
                    },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }
        public void CreateDocTotalOrders(PdfInfoTotalOrders info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Title,
                Style = "NormalTitle"
            });
            CreateTable(new List<string> { "3cm", "6cm", "6cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата заказа", "Общее количество", "Общая сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            foreach (var order in info.TotalOrders)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { order.DateCreate.ToShortDateString(), order.TotalCount.ToString(), order.TotalSum.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }
            SavePdf(info);
        }
        // Создание doc-файла
        protected abstract void CreatePdf(PdfInfo info);
        // Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        // Создание таблицы
        protected abstract void CreateTable(List<string> columns);
        // Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        // Сохранение файла
        protected abstract void SavePdf(PdfInfo info);
    }
}
