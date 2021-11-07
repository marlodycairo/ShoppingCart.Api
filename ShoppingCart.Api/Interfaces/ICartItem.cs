using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Interfaces
{
    public interface ICartItem
    {
        void AddCartItem(CartItem cartItem);
        List<CartItem> GetCartItems();
        CartItem GetCartItemById(int id);
        void DeleteCartItem(int id );
    }
}
