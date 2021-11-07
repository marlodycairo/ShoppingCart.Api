using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
    }
}
