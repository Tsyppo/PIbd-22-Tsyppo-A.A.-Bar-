using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarContracts.Enums;

namespace AbstractBarBusinessLogic.BusinessLogics
{
    public class CocktailLogic : ICocktailLogic
    {
        private readonly ICocktailStorage _cocktailStorage;

        public CocktailLogic(ICocktailStorage cocktailStorage)
        {
            _cocktailStorage = cocktailStorage;
        }

        public List<CocktailViewModel> Read(CocktailBindingModel model)
        {
            if (model == null)
            {
                return _cocktailStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CocktailViewModel>
                {
                    _cocktailStorage.GetElement(model)
                };
            }
            return _cocktailStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CocktailBindingModel model)
        {
            var element = _cocktailStorage.GetElement(new CocktailBindingModel
            {
                CocktailName = model.CocktailName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть мебель с таким названием");
            }
            if (model.Id.HasValue)
            {
                _cocktailStorage.Update(model);
            }
            else
            {
                _cocktailStorage.Insert(model);
            }
        }

        public void Delete(CocktailBindingModel model)
        {
            var element = _cocktailStorage.GetElement(new CocktailBindingModel
            {
                Id = model.Id
            });

            if (element == null)
            {
                throw new Exception("Мебель не найдена");
            }
            _cocktailStorage.Delete(model);
        }
    }
}
