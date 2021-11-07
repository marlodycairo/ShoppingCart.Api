using ShoppingCart.Api.Interfaces;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Logic
{
    public class CartItemService : ICartItem
    {
        public void AddCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public CartItem GetCartItemById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetCartItems()
        {
            throw new NotImplementedException();
        }
    }
}
