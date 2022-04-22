using AbstractBarContracts.BindingModels;
using AbstractBarContracts.StoragesContracts;
using AbstractBarContracts.ViewModels;
using AbstractBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AbstractBarFileImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        private readonly FileDataListSingleton source;

        public ComponentStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<ComponentViewModel> GetFullList()
        {
            return source.Components
                .Select(CreateModel)
                .ToList();
        }
        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Components
                .Where(rec => rec.ComponentName.Contains(model.ComponentName))
                .Select(CreateModel)
                .ToList();
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Component = source.Components
                .FirstOrDefault(rec => rec.ComponentName == model.ComponentName || rec.Id == model.Id);
            return Component != null ? CreateModel(Component) : null;
        }

        public void Insert(ComponentBindingModel model)
        {
            int maxId = source.Components.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Component { Id = maxId + 1 };
            source.Components.Add(CreateModel(model, element));
        }

        public void Update(ComponentBindingModel model)
        {
            var element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(ComponentBindingModel model)
        {
            Component element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Components.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Component CreateModel(ComponentBindingModel model, Component Component)
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
