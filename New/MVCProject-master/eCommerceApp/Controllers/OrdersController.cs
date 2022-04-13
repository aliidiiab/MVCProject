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



        #region Shoppingcart
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
        #endregion

        #region AddToShoppingCart
        public IActionResult AddToShoppingCart(int Id)
        {
            var item = ProductRepository.getbyID(Id);
            if (item != null)
            {
                ShoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(Shoppingcart));
        }
        #endregion

        #region DeleteItemFromShoppingCart
        public IActionResult DeleteItemFromShoppingCart(int Id)
        {
            var item = ProductRepository.getbyID(Id);
            if (item != null)
            {
                ShoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(Shoppingcart));
        }
        #endregion

        



    }
}
