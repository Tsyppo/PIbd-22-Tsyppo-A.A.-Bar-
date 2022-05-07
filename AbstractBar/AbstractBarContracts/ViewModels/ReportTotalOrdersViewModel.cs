using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBarContracts.ViewModels
{
    public class ReportTotalOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalSum { get; set; }
    }
}
