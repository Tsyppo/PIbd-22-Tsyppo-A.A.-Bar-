using AbstractBarContracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBarContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CocktailViewModel
    {

        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название коктейля", width: 150)]
        public string CocktailName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> CocktailComponents { get; set; }
        public string GetComponents()
        {
            string stringComponents = string.Empty;
            if (CocktailComponents != null)
            {
                foreach (var comp in CocktailComponents)
                {
                    stringComponents += comp.Key + ") " + comp.Value.Item1 + ": " + comp.Value.Item2 + ", ";
                }
            }
            return stringComponents;
        }
    }
}
