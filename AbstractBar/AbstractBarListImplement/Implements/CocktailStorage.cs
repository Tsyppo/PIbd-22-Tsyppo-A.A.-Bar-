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
            foreach (var product in source.Cocktails)
            {
                if (product.CocktailName.Contains(model.CocktailName))
                {
                    result.Add(CreateModel(product));
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
            foreach (var product in source.Cocktails)
            {
                if (product.Id == model.Id || product.CocktailName ==
                model.CocktailName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(CocktailBindingModel model)
        {
            var tempProduct = new Cocktail
            {
                Id = 1,
                ProductComponents = new
            Dictionary<int, int>()
            };
            foreach (var product in source.Cocktails)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Cocktails.Add(CreateModel(model, tempProduct));
        }
        public void Update(CocktailBindingModel model)
        {
            Cocktail tempProduct = null;
            foreach (var product in source.Cocktails)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
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
        private static Cocktail CreateModel(CocktailBindingModel model, Cocktail
        product)
        {
            product.CocktailName = model.CocktailName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.CocktailComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.CocktailComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] =
                    model.CocktailComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.CocktailComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private CocktailViewModel CreateModel(Cocktail product)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.ProductComponents)
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
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new CocktailViewModel
            {
                Id = product.Id,
                CocktailName = product.CocktailName,
                Price = product.Price,
                CocktailComponents = productComponents
            };
        }
    }
}
