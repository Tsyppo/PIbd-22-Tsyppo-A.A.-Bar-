using System.ComponentModel.DataAnnotations;

namespace AbstractBarDatabaseImplement.Models
{
    public class CocktailComponent
    {
        public int Id { get; set; }
        public int CocktailId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Cocktail Cocktail { get; set; }
    }
}
