using AbstractBarBusinessLogic.OfficePackage.HelperEnums;
using AbstractBarBusinessLogic.OfficePackage.HelperModels;

namespace AbstractBarBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
        // Создание отчета
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });
            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });
            uint rowIndex = 2;
            foreach (var gt in info.CocktailComponents)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = gt.CocktailName,
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
                foreach (var garment in gt.Components)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = garment.Item1,
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = garment.Item2.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });
                    rowIndex++;
                }
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = gt.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }
            SaveExcel(info);
        }

        public void CreateWarehouseReport(ExcelInfoWarehouses info)
        {
            CreateExcel(info);
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });
            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });
            uint rowIndex = 2;
            foreach (var wc in info.WarehouseComponents)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = wc.WarehouseName,
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
                foreach (var textile in wc.Components)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = textile.Item1,
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = textile.Item2.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBorder
                    });
                    rowIndex++;
                }
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = wc.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }
            SaveExcel(info);
        }

        // Создание excel-файла
        protected abstract void CreateExcel(ExcelInfo info);

        // Добавляем новую ячейку в лист
        protected abstract void InsertCellInWorksheet(ExcelCellParameters
        excelParams);

        // Объединение ячеек
        protected abstract void MergeCells(ExcelMergeParameters excelParams);

        // Сохранение файла
        protected abstract void SaveExcel(ExcelInfo info);
    }
}
