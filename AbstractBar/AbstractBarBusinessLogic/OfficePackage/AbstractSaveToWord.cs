using AbstractBarBusinessLogic.OfficePackage.HelperEnums;
using AbstractBarBusinessLogic.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace AbstractBarBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new
WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var garment in info.Cocktails)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {(garment.CocktailName + "    -    ", new WordTextProperties { Size = "24", Bold = true}),
                    (garment.Price.ToString() , new WordTextProperties{ Size = "24", })},
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }

        public void CreateWarehouseDoc(WordInfoWarehouses info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateTable(new List<string>() { "Название", "ФИО ответственного", "Дата создания" });
            foreach (var warehouse in info.Warehouses)
            {
                AddRowTable(new List<string>() {
                    warehouse.WarehouseName,
                    warehouse.ResponsiblePerson,
                    warehouse.DateCreate.ToShortDateString()
                });
            }
            SaveWord(info);
        }
        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);
        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);
        protected abstract void CreateTable(List<string> tableHeaderInfo);
        protected abstract void AddRowTable(List<string> tableRowInfo);
        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
