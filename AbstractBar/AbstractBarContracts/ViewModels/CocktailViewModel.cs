using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AbstractBarContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CocktailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название коктейля")]
        public string CocktailName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> CocktailComponents { get; set; }
    }
}
