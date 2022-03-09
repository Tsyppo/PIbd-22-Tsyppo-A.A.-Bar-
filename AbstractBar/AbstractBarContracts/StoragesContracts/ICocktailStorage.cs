using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.ViewModels;

namespace AbstractBarContracts.StoragesContracts
{
    public interface ICocktailStorage
    {
        List<CocktailViewModel> GetFullList();
        List<CocktailViewModel> GetFilteredList(CocktailBindingModel model);
        CocktailViewModel GetElement(CocktailBindingModel model);
        void Insert(CocktailBindingModel model);
        void Update(CocktailBindingModel model);
        void Delete(CocktailBindingModel model);
    }
}
