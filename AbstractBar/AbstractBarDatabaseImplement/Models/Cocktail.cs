using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractBarDatabaseImplement.Models
{
    public class Cocktail
    {
        public int Id { get; set; }
        [Required]
        public string CocktailName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<CocktailComponent> CocktailComponents { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<Order> Orders { get; set; }
    }
}
