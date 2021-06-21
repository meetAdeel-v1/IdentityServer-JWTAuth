using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer_JWTAuth.Context;
using IdentityServer_JWTAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                            return BadRequest("User cannot login due to wrong user credentials.");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            return Ok();
        }


        // GET: HomeController/Create
        //[HttpPost]
        public async Task<IActionResult> Create(string UName, string pass)
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

        public async Task<IActionResult> CreateEmployee(Employee empObj)
        {
            Employee emp = new Employee() {FirstName="Adeel", LastName="Ahmed", Email="test@west.com", Address="US" };
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _context.Add(emp);
                    _context.SaveChanges();
                    
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return Ok("Model State is not valid.");
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
