using ShoppingCart.Api.Context;
using ShoppingCart.Api.Interfaces;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Logic
{
    public class CustomerService : ICustomer
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCustomer(Customer customer)
        {
            Guid guid = Guid.NewGuid();

            customer.CustomerID = guid.ToString();

            var customerExist = context.Customers.Any(p => p.Id == customer.Id);

            if (customerExist)
            {
                throw new Exception("The customer already exist.");
            }

            Customer customer1 = new Customer
            {
                Id = customer.Id,
                CustomerID = customer.CustomerID,
                CustomerFullName = customer.CustomerFullName,
                IDCard = customer.IDCard,
                Address = customer.Address,
                CellPhone = customer.CellPhone,
                EMail = customer.EMail,
                City = customer.City
            };

            context.Add(customer1);

            context.SaveChanges();
        }
    }
}
