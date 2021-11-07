using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Api.Context;
using ShoppingCart.Api.Logic;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ShoppingCartActions shoppingCartActions;
        private readonly ApplicationDbContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ShoppingCartActions shoppingCartActions,
            ApplicationDbContext context)
        {
            _logger = logger;
            this.shoppingCartActions = shoppingCartActions;
            this.context = context;
        }

        public string ShoppingCartId { get; set; }


        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost]
        public void AddShoppingCart(int id)
        {
            //shoppingCartActions.AddToCart(id);
            ShoppingCartId = GetCartId();

            var cartItem = context.ShoppingCartItems.SingleOrDefault(
                p => p.CartId == ShoppingCartId && p.ProductId == id);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = context.Products.SingleOrDefault(
                        p => p.ProductId == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            context.SaveChanges();
        }

        [HttpGet]
        public string GetCartId()
        {
            return ToString();
        }
    }
}
