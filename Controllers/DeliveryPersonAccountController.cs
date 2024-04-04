using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Neerogilksample.Data;
using Neerogilksample.Data.Static;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    public class DeliveryPersonAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public DeliveryPersonAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login() => View(new DeliveryPersonLoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(DeliveryPersonLoginVM dpersonloginVM)
        {
            if (!ModelState.IsValid) return View(dpersonloginVM);
            var user = await _userManager.FindByEmailAsync(dpersonloginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, dpersonloginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, dpersonloginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("AdminDashboard", "DeliveryPersonAccount");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(dpersonloginVM);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(dpersonloginVM);
        }
        public IActionResult Register() => View(new DeliveryPersonRegisterVM());
        [HttpPost]
        public async Task<IActionResult> Register(DeliveryPersonRegisterVM dpersonregisterVM)
        {
            if (!ModelState.IsValid) return View(dpersonregisterVM);
            var user = await _userManager.FindByEmailAsync(dpersonregisterVM.DPersonEmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(dpersonregisterVM);
            }
            var newUser = new ApplicationUser()
            {
                DeliveryPersonFirstName = dpersonregisterVM.DeliveryPersonFirstName,
                DeliveryPersonLastName = dpersonregisterVM.DeliveryPersonLastName,
                Email = dpersonregisterVM.DPersonEmailAddress,
                UserName = dpersonregisterVM.DPersonEmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, dpersonregisterVM.DPersonPassword);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.DeliveryPerson);
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdminDashboard()
        {

            return View();

        }

    }
}
