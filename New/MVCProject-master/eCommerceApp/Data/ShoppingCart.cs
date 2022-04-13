using eCommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceApp.Repos
{
    public class ShoppingCart : IShoppingCart
    {
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        eCommerceAppEntities Context;

        //For Injection
        public ShoppingCart(eCommerceAppEntities _Context)
        {
            Context = _Context;
        }

        #region MyRegion

        public  static ShoppingCart GetShoppingCart(IServiceProvider ServiceProvider)
        {
            ISession session = ServiceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = ServiceProvider.GetService<eCommerceAppEntities>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId,
            };
             
        }

        #endregion

        #region GetShoppingCartItems
        public List<ShoppingCartItem> GetShoppingCartItems()
        {

            return ShoppingCartItems ?? (ShoppingCartItems = Context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToList());
        } 
        #endregion

        #region ShoppingItemTotal
        public decimal ShoppingItemTotal()
        {
            var total = Context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Product.ProductPrice * n.Amount).Sum();
            return total;
        } 
        #endregion

        #region Add Item To Cart
        public void AddItemToCart(Product product)
        {
            var shoppingCartItem = Context.ShoppingCartItems.FirstOrDefault(p => p.Product.ProductID == product.ProductID && p.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1,
                };
                Context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            Context.SaveChanges();
        }
        #endregion

        #region Rmove Item From Cart


        public void RemoveItemFromCart(Product product)
        {
            var shoppingCartItem = Context.ShoppingCartItems.FirstOrDefault(p => p.Product.ProductID == product.ProductID && p.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {

                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    Context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
                    Context.SaveChanges();
        }


        #endregion










    }

}

