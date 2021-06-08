using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer_JWTAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer_JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SecurityController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] User login)
        {
            var user = await AuthenticateUser(login);
            if (user != null) 
                return Ok(new {token=GenerateJasonWebToken(user) });
            else
                return BadRequest(new {message="Invalid Username or Password" });
        }
        [HttpPost]
        [AllowAnonymous]
        public void Register([FromBody] UserSignup register)
        {

        }
        public async Task<string> GenerateJasonWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            return "";
        }
        public async Task<User> AuthenticateUser(User login)
        {
            //if(login.username || login.email exists)
            return login;
        }
    }
}
