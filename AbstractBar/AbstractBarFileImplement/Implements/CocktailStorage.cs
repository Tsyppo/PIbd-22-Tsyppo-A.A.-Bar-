using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractBarFileImplement.Implements
{
    public class CocktailStorage : ICocktailStorage
    {
        private readonly FileDataListSingleton source;

        public CocktailStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<CocktailViewModel> GetFullList()
        {
            return source.Cocktails
                .Select(CreateModel)
                .ToList();
        }

        public List<CocktailViewModel> GetFilteredList(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Cocktails
                .Where(rec => rec.CocktailName.Contains(model.CocktailName))
                .Select(CreateModel)
                .ToList();
        }

        public CocktailViewModel GetElement(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Cocktail = source.Cocktails
                .FirstOrDefault(rec => rec.CocktailName == model.CocktailName || rec.Id == model.Id);
            return Cocktail != null ? CreateModel(Cocktail) : null;
        }

        public void Insert(CocktailBindingModel model)
        {
            int maxId = source.Cocktails.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Cocktail
            {
                Id = maxId + 1,
                CocktailComponents = new Dictionary<int, int>()
            };
            source.Cocktails.Add(CreateModel(model, element));
        }

        public void Update(CocktailBindingModel model)
        {
            var element = source.Cocktails
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(CocktailBindingModel model)
        {
            Cocktail element = source.Cocktails
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Cocktails.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Cocktail CreateModel(CocktailBindingModel model, Cocktail
        Cocktail)
        {
            Cocktail.CocktailName = model.CocktailName;
            Cocktail.Price = model.Price;
            foreach (var key in Cocktail.CocktailComponents.Keys.ToList())
            {
                if (!model.CocktailComponents.ContainsKey(key))
                {
                    Cocktail.CocktailComponents.Remove(key);
                }
            }
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
            return new CocktailViewModel
            {
                Id = Cocktail.Id,
                CocktailName = Cocktail.CocktailName,
                Price = Cocktail.Price,
                CocktailComponents = Cocktail.CocktailComponents.ToDictionary(recGT => recGT.Key, recGT => (source.Components.FirstOrDefault(recT => recT.Id == recGT.Key)?.ComponentName, recGT.Value))
            };
        }
    }
}
