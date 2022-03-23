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
        public List<CocktailViewModel> GetFullList()
        {
            var result = new List<CocktailViewModel>();
            foreach (var component in source.Cocktails)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<CocktailViewModel> GetFilteredList(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<CocktailViewModel>();
            foreach (var cocktail in source.Cocktails)
            {
                if (cocktail.CocktailName.Contains(model.CocktailName))
                {
                    result.Add(CreateModel(cocktail));
                }
            }
            return result;
        }
        public CocktailViewModel GetElement(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var cocktail in source.Cocktails)
            {
                if (cocktail.Id == model.Id || cocktail.CocktailName == model.CocktailName)
                {
                    return CreateModel(cocktail);
                }
            }
            return null;
        }
        public void Insert(CocktailBindingModel model)
        {
            var tempCocktail = new Cocktail
            {
                Id = 1,
                CocktailComponents = new Dictionary<int, int>()
            };
            foreach (var cocktail in source.Cocktails)
            {
                if (cocktail.Id >= tempCocktail.Id)
                {
                    tempCocktail.Id = cocktail.Id + 1;
                }
            }
            source.Cocktails.Add(CreateModel(model, tempCocktail));
        }
        public void Update(CocktailBindingModel model)
        {
            Cocktail tempCocktail = null;
            foreach (var cocktail in source.Cocktails)
            {
                if (cocktail.Id == model.Id)
                {
                    tempCocktail = cocktail;
                }
            }
            if (tempCocktail == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempCocktail);
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
        private static Cocktail CreateModel(CocktailBindingModel model, Cocktail cocktail)
        {
            cocktail.CocktailName = model.CocktailName;
            cocktail.Price = model.Price;
            // удаляем убранные
            foreach (var key in cocktail.CocktailComponents.Keys.ToList())
            {
                if (!model.CocktailComponents.ContainsKey(key))
                {
                    cocktail.CocktailComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.CocktailComponents)
            {
                if (cocktail.CocktailComponents.ContainsKey(component.Key))
                {
                    cocktail.CocktailComponents[component.Key] =
                    model.CocktailComponents[component.Key].Item2;
                }
                else
                {
                    cocktail.CocktailComponents.Add(component.Key,
                    model.CocktailComponents[component.Key].Item2);
                }
            }
            return cocktail;
        }
        private CocktailViewModel CreateModel(Cocktail cocktail)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            var cocktailComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in cocktail.CocktailComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                cocktailComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new CocktailViewModel
            {
                Id = cocktail.Id,
                CocktailName = cocktail.CocktailName,
                Price = cocktail.Price,
                CocktailComponents = cocktailComponents
            };
        }
    }
}
