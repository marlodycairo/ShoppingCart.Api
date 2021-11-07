using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Context;
using ShoppingCart.Api.Interfaces;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Logic
{
    public class ProductsService : IProducts
    {
        private readonly ApplicationDbContext context;

        public ProductsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetAllProducts(int? categoryId)
        {
            IQueryable<Product> query = context.Products;

            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            return query;
        }
    }
}
