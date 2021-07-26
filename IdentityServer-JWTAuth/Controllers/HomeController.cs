using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using IdentityServer_JWTAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserSignup = IdentityServer_JWTAuth.Models.UserSignup;

namespace IdentityServer_JWTAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;
        private readonly SignInManager<User> _signInManager;
        public HomeController(UserManager<User> userManager, ApplicationContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //?param1 = value1 & param2 = value2
            var result = _userManager.Users;
            if (result != null)
                return Ok(result);
            else
                return BadRequest("No User Found.");
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Ok("User exists and Logged In Successfully!");
                        }
                        else
                        {
                            ModelState.AddModelError("Test","Incorrect Username or Password!");
                            return View(login);
                        }
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
                
            }
            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(string UName, string pass)
        {
            if (ModelState.IsValid)
            {
                //"Abc!23@"
                User user = new User()
                {
                    UserName = UName,
                    Email = "test@west.com",
                };
                try
                {
                    var result = await _userManager.CreateAsync(user, pass);
                    if (result.Succeeded)
                        return Ok("User has been created Sucessfully!");
                    else
                        return BadRequest("Error in creating User.");
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return Ok("Model State is not valid.");
        }
    }
}
