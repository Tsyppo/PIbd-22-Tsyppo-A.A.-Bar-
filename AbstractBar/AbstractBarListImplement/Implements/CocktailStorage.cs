using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarListImplement.Models;


namespace AbstractBarListImplement.Implements
{
    public class CocktailStorage : ICocktailStorage
    {
        private readonly DataListSingleton source;

        public CocktailStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        private static Cocktail CreateModel(CocktailBindingModel model, Cocktail
        Cocktail)
        {
            Cocktail.CocktailName = model.CocktailName;
            Cocktail.Price = model.Price;
            // удаляем убранные
            foreach (var key in Cocktail.CocktailComponents.Keys.ToList())
            {
                if (!model.CocktailComponents.ContainsKey(key))
                {
                    Cocktail.CocktailComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var Component in model.CocktailComponents)
            {
                if (Cocktail.CocktailComponents.ContainsKey(Component.Key))
                {
                    Cocktail.CocktailComponents[Component.Key] =
                    model.CocktailComponents[Component.Key].Item2;
                }
                else
                {
                    Cocktail.CocktailComponents.Add(Component.Key,
                    model.CocktailComponents[Component.Key].Item2);
                }
            }
            return Cocktail;
        }

        private CocktailViewModel CreateModel(Cocktail Cocktail)
        {
            // требуется дополнительно получить список тканей для швейного изделия с
            // названиями и их количество
            var CocktailComponents = new Dictionary<int, (string, int)>();
            foreach (var gt in Cocktail.CocktailComponents)
            {
                string ComponentName = string.Empty;
                foreach (var Component in source.Components)
                {
                    if (gt.Key == Component.Id)
                    {
                        ComponentName = Component.ComponentName;
                        break;
                    }
                }
                CocktailComponents.Add(gt.Key, (ComponentName, gt.Value));
            }
            return new CocktailViewModel
            {
                Id = Cocktail.Id,
                CocktailName = Cocktail.CocktailName,
                Price = Cocktail.Price,
                CocktailComponents = CocktailComponents
            };
        }

        public void Delete(CocktailBindingModel model)
        {
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                if (source.Cocktails[i].Id == model.Id)
                {
                    source.Cocktails.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");

        }

        public CocktailViewModel GetElement(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var Cocktail in source.Cocktails)
            {
                if (Cocktail.Id == model.Id || Cocktail.CocktailName ==
                model.CocktailName)
                {
                    return CreateModel(Cocktail);
                }
            }
            return null;

        }

        public List<CocktailViewModel> GetFilteredList(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<CocktailViewModel>();
            foreach (var Cocktail in source.Cocktails)
            {
                if (Cocktail.CocktailName.Contains(model.CocktailName))
                {
                    result.Add(CreateModel(Cocktail));
                }
            }
            return result;
        }

        public List<CocktailViewModel> GetFullList()
        {
            var result = new List<CocktailViewModel>();

            foreach (var Cocktail in source.Cocktails)
            {
                result.Add(CreateModel(Cocktail));
            }
            return result;
        }

        public void Insert(CocktailBindingModel model)
        {
            var tempCocktail = new Cocktail
            {
                Id = 1,
                CocktailComponents = new Dictionary<int, int>()
            };
            foreach (var Cocktail in source.Cocktails)
            {
                if (Cocktail.Id >= tempCocktail.Id)
                {
                    tempCocktail.Id = Cocktail.Id + 1;
                }
            }
            source.Cocktails.Add(CreateModel(model, tempCocktail));
        }

        public void Update(CocktailBindingModel model)
        {
            Cocktail tempCocktail = null;
            foreach (var Cocktail in source.Cocktails)
            {
                if (Cocktail.Id == model.Id)
                {
                    tempCocktail = Cocktail;
                }
            }
            if (tempCocktail == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempCocktail);

        }
    }
}