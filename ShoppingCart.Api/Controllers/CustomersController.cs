using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Interfaces;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer customer;

        public CustomersController(ICustomer customer)
        {
            this.customer = customer;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customerModel)
        {
            customer.AddCustomer(customerModel);

            return Ok();
        }
    }
}
