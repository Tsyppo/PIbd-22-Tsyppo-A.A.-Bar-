using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.Enums;

namespace AbstractBarContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string CocktailName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }

    }
}
