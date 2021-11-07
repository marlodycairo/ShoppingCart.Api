using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Interfaces
{
    public interface ICustomer
    {
        void AddCustomer(Customer customer);
    }
}
