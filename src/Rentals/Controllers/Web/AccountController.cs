using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rentals.ViewModels;
using Rentals.Model;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentals.Controllers.Web
{
    public class AccountController : Controller
    {
        private SignInManager<RentalUser> _signInManager;
        private ILogger<AccountController> _logger;
        private UserManager<RentalUser> _userManager;

        public AccountController(SignInManager<RentalUser> signInManager ,ILogger<AccountController> logger
            , UserManager<RentalUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var user = new RentalUser()
            {
                UserName = vm.UserName,
                Email = "ronit@cybage.com"
            };
            await _userManager.CreateAsync(user, vm.Password);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl )
        {
            _logger.LogInformation("Enterinf Login");
            if (ModelState.IsValid)
            {
                var signInResult=  await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
                if(signInResult.Succeeded)
                {
                    if(string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("CurrentReservation", "Customer");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }

                else
                {
                    _logger.LogError("Incorrect Credentials");
                    ModelState.AddModelError("", "Username or password is incorrect");
                }
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
