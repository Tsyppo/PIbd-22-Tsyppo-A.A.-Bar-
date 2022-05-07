using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractBarDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using var context = new AbstractBarDatabase();
            return context.Components
            .Select(CreateModel)
            .ToList();

        }

        public void Delete(ComponentBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            Component element = context.Components.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Components.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractBarDatabase();
            var Component = context.Components
            .FirstOrDefault(rec => rec.ComponentName == model.ComponentName || rec.Id
            == model.Id);
            return Component != null ? CreateModel(Component) : null;
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractBarDatabase();
            return context.Components
            .Where(rec => rec.ComponentName.Contains(model.ComponentName))
           .Select(CreateModel)
            .ToList();

        }

        public void Insert(ComponentBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            context.Components.Add(CreateModel(model, new Component()));
            context.SaveChanges();
        }

        public void Update(ComponentBindingModel model)
        {
            using var context = new AbstractBarDatabase();
            var element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        private static Component CreateModel(ComponentBindingModel model, Component
Component)
        {
            Component.ComponentName = model.ComponentName;
            return Component;
        }

        private static ComponentViewModel CreateModel(Component Component)
        {
            return new ComponentViewModel
            {
                Id = Component.Id,
                ComponentName = Component.ComponentName
            };
        }
    }
}
