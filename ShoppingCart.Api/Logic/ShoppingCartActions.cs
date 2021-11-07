using ShoppingCart.Api.Context;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        private ApplicationDbContext context;

        public ShoppingCartActions(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string ShoppingCartId { get; set; }

        //pendiente validar session

        //public void AddToCart(int id)
        //{
        //    ShoppingCartId = GetCartId();

        //    var cartItem = context.ShoppingCartItems.SingleOrDefault(
        //        p => p.CartId == ShoppingCartId && p.ProductId == id);

        //    if (cartItem == null)
        //    {
        //        cartItem = new CartItem
        //        {
        //            ItemId = Guid.NewGuid().ToString(),
        //            ProductId = id,
        //            CartId = ShoppingCartId,
        //            Product = context.Products.SingleOrDefault(
        //                p => p.Id == id),
        //            Quantity = 1,
        //            DateCreated = DateTime.Now
        //        };

        //        context.ShoppingCartItems.Add(cartItem);
        //    }
        //    else
        //    {
        //        cartItem.Quantity++;
        //    }
        //    context.SaveChanges();
        //}

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        public string GetCartId()
        {
            return ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return context.ShoppingCartItems.Where(
                p => p.CartId == ShoppingCartId).ToList();
        }
    }
}
