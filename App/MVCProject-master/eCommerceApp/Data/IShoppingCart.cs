using eCommerceApp.Models;
using System.Collections.Generic;

namespace eCommerceApp.Repos
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        void AddItemToCart(Product product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void RemoveItemFromCart(Product product);
        decimal ShoppingItemTotal();
    }
}