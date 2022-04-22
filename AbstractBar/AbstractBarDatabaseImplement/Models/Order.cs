using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.Enums;

namespace AbstractBarDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CocktailId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Cocktail Cocktail { get; set; }
        public virtual Client Client { get; set; }
    }
}
