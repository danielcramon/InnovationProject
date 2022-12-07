using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_application.Areas.Identity.Data;
using web_application.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_application.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<EducationTubeUser> _signInManager;
        private readonly UserManager<EducationTubeUser> _userManager;

        public AuthenticationController(SignInManager<EducationTubeUser> signInManager, UserManager<EducationTubeUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            Console.WriteLine(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationViewModel avm)
        {
            if (!ModelState.IsValid) { return View(avm); }

            var result = await _signInManager.PasswordSignInAsync(avm.Email, avm.Password, true, false);
            if (result.Succeeded == false) { ModelState.AddModelError("", "Incorrect information"); return View(avm); }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthenticationViewModel avm)
        {
            if (ModelState.IsValid)
            {
                var user = new EducationTubeUser() { UserName = avm.Email, Email = avm.Email };
                var createResult = await _userManager.CreateAsync(user, avm.Password);
                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "SecurityIssuePost");
                }
            }

            return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
