using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AbstractBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ICocktailLogic _cocktail;
        private readonly IMessageInfoLogic _messageInfo;
        public MainController(IOrderLogic order, ICocktailLogic cocktail, IMessageInfoLogic messageInfo)
        {
            _order = order;
            _cocktail = cocktail;
            _messageInfo = messageInfo;
        }
        [HttpGet]
        public List<CocktailViewModel> GetCocktailList() => _cocktail.Read(null)?.ToList();
        [HttpGet]
        public CocktailViewModel GetCocktail(int cocktailId) => _cocktail.Read(new CocktailBindingModel
        { Id = cocktailId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _messageInfo.Read(new MessageInfoBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
