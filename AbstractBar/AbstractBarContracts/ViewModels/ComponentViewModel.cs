using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AbstractBarContracts.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
