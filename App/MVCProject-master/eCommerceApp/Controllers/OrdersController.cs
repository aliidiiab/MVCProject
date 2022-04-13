using eCommerceApp.Repos;
using eCommerceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using eCommerceApp.Models;

namespace eCommerceApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly IShoppingCart ShoppingCart;

        public OrdersController(IProductRepository _IProductRepository, IShoppingCart _IShoppingCart )
        {
            ProductRepository = _IProductRepository;
            ShoppingCart = _IShoppingCart;

        }



        public IActionResult Shoppingcart()
        {
            //the list of the items 
            var items = ShoppingCart.GetShoppingCartItems();


            ShoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = (ShoppingCart)ShoppingCart,
                ShoppingCartTotal = ShoppingCart.ShoppingItemTotal(),
            };

            return View(response);
        }
    }
}
