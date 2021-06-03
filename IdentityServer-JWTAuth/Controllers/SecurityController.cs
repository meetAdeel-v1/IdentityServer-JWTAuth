using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer_JWTAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer_JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
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
            return "";
        }
        public async Task<User> AuthenticateUser(User login)
        {
            //if(login.username || login.email exists)
            return login;
        }
    }
}
