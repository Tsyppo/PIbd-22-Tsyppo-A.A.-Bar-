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
        public MainController(IOrderLogic order, ICocktailLogic cocktail)
        {
            _order = order;
            _cocktail = cocktail;
        }
        [HttpGet]
        public List<CocktailViewModel> GetCocktailList() => _cocktail.Read(null)?.ToList();
        [HttpGet]
        public CocktailViewModel GetCocktail(int cocktailId) => _cocktail.Read(new CocktailBindingModel
        { Id = cocktailId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
