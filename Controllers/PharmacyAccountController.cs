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

    public class PharmacyAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public PharmacyAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login() => View(new PharmacyLoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(PharmacyLoginVM pharmacyloginVM)
        {
            if (!ModelState.IsValid) return View(pharmacyloginVM);
            var user = await _userManager.FindByEmailAsync(pharmacyloginVM.PharamcyEmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, pharmacyloginVM.PharmacyPassword);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, pharmacyloginVM.PharmacyPassword, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("AdminDashboard", "PharmacyAccount");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(pharmacyloginVM);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(pharmacyloginVM);
        }
        public IActionResult Register() => View(new PharmacyRegisterVM());
        [HttpPost]
        public async Task<IActionResult> Register(PharmacyRegisterVM pharmacyregisterVM)
        {
            if (!ModelState.IsValid) return View(pharmacyregisterVM);
            var user = await _userManager.FindByEmailAsync(pharmacyregisterVM.PharamcyEmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(pharmacyregisterVM);
            }
            var newUser = new ApplicationUser()
            {
                PharmacyName = pharmacyregisterVM.PharmacyName,
                PharmacyOwnerName = pharmacyregisterVM.PharmacyOwnerName,
                Email = pharmacyregisterVM.PharamcyEmailAddress,
                UserName = pharmacyregisterVM.PharamcyEmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, pharmacyregisterVM.PharmacyPassword);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Pharmacist);
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
