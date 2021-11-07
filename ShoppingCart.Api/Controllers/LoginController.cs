using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Api.Context;
using ShoppingCart.Api.Logic;
using ShoppingCart.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;
        private readonly LoginService loginService;

        public LoginController(ApplicationDbContext context, IConfiguration configuration,
            LoginService loginService)
        {
            this.context = context;
            this.configuration = configuration;
            this.loginService = loginService;
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            ActionResult response = Unauthorized();

            var logUser = loginService.AuthenticateUser(user);

            if (logUser != null)
            {
                var tokenString = BuildToken(logUser);

                response = tokenString;
            }

            return response;
        }

        private ActionResult BuildToken(User userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Llave_Secreta"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: expiration,
           
                signingCredentials: credentials);

            return Ok( new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });
        }
    }
}
