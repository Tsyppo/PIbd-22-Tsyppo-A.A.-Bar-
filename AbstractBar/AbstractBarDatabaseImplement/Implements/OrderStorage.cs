using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBarDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new AbstractBarDatabase();
            return context.Orders.Include(rec => rec.Cocktail).Select(CreateModel).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new AbstractBarDatabase();
            return context.Orders.Include(rec => rec.Cocktail).
                Where(rec => rec.CocktailId == model.CocktailId).Select(CreateModel).ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new AbstractBarDatabase();
            var order = context.Orders.Include(rec => rec.Cocktail).
               FirstOrDefault(rec => rec.CocktailId == model.CocktailId || rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            Order order = new Order();
            CreateModel(model, order, context);
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element, context);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            };
        }

        private static Order CreateModel(OrderBindingModel model, Order order, AbstractBarDatabase context)
        {
            order.CocktailId = model.CocktailId;
            order.Cocktail = context.Cocktails.FirstOrDefault(rec => rec.Id == model.CocktailId);
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CocktailId = order.CocktailId,
                CocktailName = order.Cocktail.CocktailName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
