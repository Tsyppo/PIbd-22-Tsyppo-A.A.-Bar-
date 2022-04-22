using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractBarContracts.Enums;
using AbstractBarFileImplement.Models;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AbstractBarFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string CocktailFileName = "Cocktail.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        public List<Implementer> Implementers { get; set; }
        public List<Client> Clients { get; set; }
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Cocktails = LoadCocktails();
            Clients = LoadClients();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveCocktails();
            SaveClients();
            SaveImplementers();
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                var xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Imlementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Attribute("ImplementerFIO").Value,
                        PauseTime = Convert.ToInt32(elem.Attribute("PauseTime").Value),
                        WorkingTime = Convert.ToInt32(elem.Attribute("WorkingTime").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    var dateImpl = elem.Element("DateImplement").Value;
                    if (dateImpl != string.Empty)
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            CocktailId = Convert.ToInt32(elem.Element("CocktailId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                            DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                            DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                            Convert.ToDateTime(elem.Element("DateImplement").Value),
                        });
                    }
                    else
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            CocktailId = Convert.ToInt32(elem.Element("CocktailId").Value),
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                            DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value)
                        });
                    }
                }
            }
            return list;
        }
        private List<Cocktail> LoadCocktails()
        {
            var list = new List<Cocktail>();
            if (File.Exists(CocktailFileName))
            {
                var xDocument = XDocument.Load(CocktailFileName);
                var xElements = xDocument.Root.Elements("Cocktail").ToList();
                foreach (var elem in xElements)
                {
                    var cocktailComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("CocktailComponents").Elements("CocktailComponent").ToList())
                    {
                        cocktailComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Cocktail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CocktailName = elem.Element("CocktailName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        CocktailComponents = cocktailComp
                    });
                }
            }
            return list;
        }
        private void SaveImplementers()
        {
            var xElement = new XElement("Implementers");
            foreach (var implementer in Implementers)
            {
                xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XAttribute("ImplementerFIO", implementer.ImplementerFIO),
                    new XAttribute("WorkingTime", implementer.WorkingTime),
                    new XAttribute("PauseTime", implementer.PauseTime)));
            }
            var xDocument = new XDocument(xElement);
            xDocument.Save(ImplementerFileName);
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("CocktailId", order.CocktailId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveCocktails()
        {
            if (Cocktails != null)
            {
                var xElement = new XElement("Cocktails");
                foreach (var cocktail in Cocktails)
                {
                    var compElement = new XElement("CocktailComponents");
                    foreach (var component in cocktail.CocktailComponents)
                    {
                        compElement.Add(new XElement("CocktailComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Cocktail",
                     new XAttribute("Id", cocktail.Id),
                     new XElement("CocktailName", cocktail.CocktailName),
                     new XElement("Price", cocktail.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(CocktailFileName);
            }
        }

        public static void Save()
        {
            instance.SaveOrders();
            instance.SaveCocktails();
            instance.SaveComponents();
            instance.SaveClients();
            instance.SaveImplementers();
        }
    }
}
