using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_application.Areas.Identity.Data;
using web_application.Data;
using web_application.Models;

namespace web_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<EducationTubeUser> _userManager;
        private readonly EducationTubeContext _educationTubeContext;

        public HomeController(ILogger<HomeController> logger, UserManager<EducationTubeUser> userManager, EducationTubeContext educationTubeContext)
        {
            _logger = logger;
            _userManager = userManager;
            _educationTubeContext = educationTubeContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult GetVideo()
        {
            return View();
        }

        public async Task<IActionResult> BuyVideo()
        {
            var educationTubeUser = await _userManager.GetUserAsync(User);
            if(educationTubeUser.Tokens >= 5)
            {
                educationTubeUser.Tokens = educationTubeUser.Tokens - 5;
                await _educationTubeContext.SaveChangesAsync();
                return RedirectToAction("GetVideo", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public IActionResult BuyTokens()
        {
            return View();
        }

        public async Task<IActionResult> BuyTokenAmmount(int tokens)
        {
            var educationTubeUser = await _userManager.GetUserAsync(User);
            educationTubeUser.Tokens = educationTubeUser.Tokens + tokens;
            await _educationTubeContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
