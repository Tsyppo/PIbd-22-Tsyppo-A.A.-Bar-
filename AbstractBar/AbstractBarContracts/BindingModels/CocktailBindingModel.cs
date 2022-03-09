using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBarContracts.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CocktailBindingModel
    {
        public int? Id { get; set; }
        public string CocktailName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> CocktailComponents { get; set; }
    }
}
