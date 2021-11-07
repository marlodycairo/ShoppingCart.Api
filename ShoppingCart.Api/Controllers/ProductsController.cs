using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts products;

        public ProductsController(IProducts products)
        {
            this.products = products;
        }

        [HttpGet]
        public List<Product> GetProducts(int? categoryId)
        {
            var allProducts = products.GetAllProducts(categoryId);

            return allProducts.ToList();
         }
    }
}
