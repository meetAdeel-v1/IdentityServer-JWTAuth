using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        public SecurityController(IConfiguration config, ApplicationContext context, UserManager<User> userManager)
        {
            _config = config;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] Employee login)
        {
            var user = await AuthenticateUser(login);
            if (user != null) 
                return Ok(new {token=GenerateJasonWebToken(user) });
            else
                return BadRequest(new {message="Invalid Username or Password" });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserSignup register)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    //UserName = register.FirstName,
                    Email = register.Email,
                    PhoneNumber=register.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                    //Add AppUser
                    return Ok("User has been created Sucessfully!");
                else
                    return BadRequest("Error in creating User.");
            }
            return Ok("Model State is not valid.");
        }
        public async Task<string> GenerateJasonWebToken(Employee userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<Employee> AuthenticateUser(Employee login)
        {
            //if(login.username || login.email exists)
            var test = _context.Users.FirstOrDefault();
            return login;
        }
    }
}
