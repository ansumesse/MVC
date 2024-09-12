using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVC_Project.Models;
using MVC_Project.ViewModels;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signIn;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newRegister)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = newRegister.UserName,
                    Email = newRegister.Email,
                    Address = newRegister.Address
                };
                var result = await userManager.CreateAsync(user, newRegister.Password);
                if (result.Succeeded)
                {
                    // create cookies
                    await userManager.AddToRoleAsync(user, "Student");
                    await signIn.SignInAsync(user, false);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    // errors
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }

            }

            return View(newRegister);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterViewModel newRegister)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = newRegister.UserName,
                    Email = newRegister.Email,
                    Address = newRegister.Address
                };
                var result = await userManager.CreateAsync(user, newRegister.Password);
                if (result.Succeeded)
                {
                    // create cookies
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signIn.SignInAsync(user, false);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    // errors
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }

            }

            return View(newRegister);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userLogin.UserName);
                var found = await userManager.CheckPasswordAsync(user, userLogin.Password);
                if (found)
                {
                    await signIn.SignInAsync(user, userLogin.RememberMe);
                    return RedirectToAction("Index", "Course");

                }
            }
            ModelState.AddModelError("", "UserName or Password is wrong");
            return View(userLogin);
        }
        
        public IActionResult LogOut()
        {
            signIn.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
