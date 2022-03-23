using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractBarDatabaseImplement.Implements
{
    public class CocktailStorage : ICocktailStorage
    {
        public List<CocktailViewModel> GetFullList()
        {
            using var context = new AbstractBarDatabase();
            return context.Cocktails
            .Include(rec => rec.CocktailComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<CocktailViewModel> GetFilteredList(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractBarDatabase();
            return context.Cocktails
            .Include(rec => rec.CocktailComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.CocktailName.Contains(model.CocktailName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public CocktailViewModel GetElement(CocktailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractBarDatabase();
            var Cocktail = context.Cocktails
            .Include(rec => rec.CocktailComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.CocktailName == model.CocktailName || rec.Id == model.Id);
            return Cocktail != null ? CreateModel(Cocktail) : null;
        }
        public void Insert(CocktailBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Cocktails.Add(CreateModel(model, new Cocktail(),
                context));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(CocktailBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Cocktails.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(CocktailBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            Cocktail element = context.Cocktails.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Cocktails.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Cocktail CreateModel(CocktailBindingModel model, Cocktail Cocktail, AbstractBarDatabase context)
        {
            Cocktail.CocktailName = model.CocktailName;
            Cocktail.Price = model.Price;
            if (model.Id.HasValue)
            {
                var CocktailComponents = context.CocktailComponents.Where(rec =>
                rec.CocktailId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.CocktailComponents.RemoveRange(CocktailComponents.Where(rec =>
                !model.CocktailComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in CocktailComponents)
                {
                    updateComponent.Count =
                   model.CocktailComponents[updateComponent.ComponentId].Item2;
                    model.CocktailComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.CocktailComponents)
            {
                context.CocktailComponents.Add(new CocktailComponent
                {
                    CocktailId = Cocktail.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return Cocktail;
        }
        private static CocktailViewModel CreateModel(Cocktail Cocktail)
        {
            return new CocktailViewModel
            {
                Id = Cocktail.Id,
                CocktailName = Cocktail.CocktailName,
                Price = Cocktail.Price,
                CocktailComponents = Cocktail.CocktailComponents
            .ToDictionary(recCC => recCC.ComponentId,
            recCC => (recCC.Component?.ComponentName, recCC.Count))
            };
        }
    }
}