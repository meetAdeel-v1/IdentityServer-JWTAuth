using IdentityServer_JWTAuth.Context;
using IdentityServer_JWTAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer_JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result =  _userManager.Users;
            if (result != null)
                return Ok(result);
            else
                return BadRequest("No User Found.");
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string GetUser(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(AppUser newUserObj)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = newUserObj.FirstName,
                    Email = newUserObj.Email,
                };
                var result = await _userManager.CreateAsync(user, newUserObj.Password);
                if (result.Succeeded)
                    return Ok("User has been created Sucessfully!");
                else
                    return BadRequest("Error in creating User.");
            }
            return Ok("Model State is not valid.");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void UpdateUser(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
