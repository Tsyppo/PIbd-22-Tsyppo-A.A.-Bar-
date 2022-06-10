﻿using AbstractBarContracts.BindingModels;
using AbstractBarContracts.Enums;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AbstractBarDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            AbstractBarDatabase context = new AbstractBarDatabase();
            return context.Orders
                .Include(rec => rec.Cocktail)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CocktailId = rec.CocktailId,
                    CocktailName = rec.Cocktail.CocktailName,
                    ClientId = rec.ClientId,
                    ImplementerId = rec.ImplementerId,
                    ClientFIO = rec.Client.ClientFIO,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty
                })
                .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            AbstractBarDatabase context = new AbstractBarDatabase();
            return context.Orders
                .Include(rec => rec.Cocktail)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Where(rec => rec.CocktailId == model.CocktailId
                    || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date)
                    || (model.ClientId.HasValue && rec.ClientId == model.ClientId)
                    || (model.SearchStatus.HasValue && !rec.ImplementerId.HasValue)
                    || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CocktailId = rec.CocktailId,
                    CocktailName = rec.Cocktail.CocktailName,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty
                })
                .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            AbstractBarDatabase context = new AbstractBarDatabase();
            Order order = context.Orders
                 .Include(rec => rec.Cocktail)
                 .Include(rec => rec.Client)
                 .Include(rec => rec.Implementer)
                 .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? new OrderViewModel
            {
                Id = order.Id,
                CocktailId = order.CocktailId,
                CocktailName = order.Cocktail.CocktailName,
                ClientId = order.ClientId,
                ClientFIO = order.Client.ClientFIO,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty
            } : null;
        }
        public void Insert(OrderBindingModel model)
        {
            AbstractBarDatabase context = new AbstractBarDatabase();
            Order order = new Order
            {
                CocktailId = model.CocktailId,
                ClientId = (int)model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
                ImplementerId = model.ImplementerId
            };
            context.Orders.Add(order);
            context.SaveChanges();
            CreateModel(model, order);
            context.SaveChanges();
        }
        public void Update(OrderBindingModel model)
        {
            AbstractBarDatabase context = new AbstractBarDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CocktailId = model.CocktailId;
            element.ClientId = (int)model.ClientId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
            element.ImplementerId = model.ImplementerId;
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(OrderBindingModel model)
        {
            AbstractBarDatabase context = new AbstractBarDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            AbstractBarDatabase context = new AbstractBarDatabase();
            Cocktail element = context.Cocktails.FirstOrDefault(rec => rec.Id == model.CocktailId);
            if (element != null)
            {
                if (element.Orders == null)
                {
                    element.Orders = new List<Order>();
                }
                element.Orders.Add(order);
                context.Cocktails.Update(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
            return order;
        }
    }
}
