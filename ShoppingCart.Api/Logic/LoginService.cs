using ShoppingCart.Api.Context;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Logic
{
    public class LoginService
    {
        private readonly ApplicationDbContext context;

        public LoginService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User AuthenticateUser(User user)
        {
            //User user = null;

            IEnumerable<User> users;

            users = context.Users.Where(p => p.UserName == user.UserName);

            if (user.UserName == users.First().UserName)
            {
                user = new User
                {
                    UserName = users.First().UserName,
                    Pass = users.First().Pass
                };
            }
            return user;
        }
    }
}
