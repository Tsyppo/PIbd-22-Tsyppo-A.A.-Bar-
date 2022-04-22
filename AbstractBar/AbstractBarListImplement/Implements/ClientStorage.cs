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
    public class ClientStorage : IClientStorage
    {
        private readonly DataListSingleton source;

        public ClientStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ClientViewModel> GetFullList()
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                result.Add(CreateModel(client));
            }
            return result;
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (client.Login.Contains(model.Login))
                {
                    result.Add(CreateModel(client));
                }
            }
            return result;
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    return CreateModel(client);
                }
            }
            return null;
        }

        public void Insert(ClientBindingModel model)
        {
            Client tempClient = new Client { Id = 1 };
            foreach (var client in source.Clients)
            {
                if (client.Id >= tempClient.Id)
                {
                    tempClient.Id = client.Id + 1;
                }
            }
            source.Clients.Add(CreateModel(model, tempClient));
        }

        public void Update(ClientBindingModel model)
        {
            Client tempClient = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    tempClient = client;
                }
            }
            if (tempClient == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempClient);
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Login = model.Login;
            client.Password = model.Password;
            return client;
        }

        private ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Login = client.Login,
                Password = client.Password
            };
        }
    }
}
