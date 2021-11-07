using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string IDCard { get;set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string EMail { get; set; }
        public string City { get; set; }
    }
}
