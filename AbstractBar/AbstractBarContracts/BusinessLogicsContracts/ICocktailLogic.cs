using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;

namespace AbstractBarContracts.BusinessLogicsContracts
{
    public interface ICocktailLogic
    {
        List<CocktailViewModel> Read(CocktailBindingModel model);
        void CreateOrUpdate(CocktailBindingModel model);
        void Delete(CocktailBindingModel model);
    }
}
