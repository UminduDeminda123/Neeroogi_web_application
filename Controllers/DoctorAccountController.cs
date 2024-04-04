using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Neerogilksample.Data;
using Neerogilksample.Data.Services;
using Neerogilksample.Data.Static;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    public class DoctorAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IDoctorsService _service;

        public DoctorAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IDoctorsService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
        }
        public IActionResult Login() => View(new DoctorLoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(DoctorLoginVM doctorloginVM)
        {
            if (!ModelState.IsValid) return View(doctorloginVM);
            var user = await _userManager.FindByEmailAsync(doctorloginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, doctorloginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, doctorloginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("AdminDashboard", "DoctorAccount");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(doctorloginVM);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(doctorloginVM);
        }
        public IActionResult Register() => View(new DoctorRegisterVM());
        [HttpPost]
        public async Task<IActionResult> Register(DoctorRegisterVM doctorregisterVM)
        {
            if (!ModelState.IsValid) return View(doctorregisterVM);
            var user = await _userManager.FindByEmailAsync(doctorregisterVM.DoctorEmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(doctorregisterVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = doctorregisterVM.FullName,
                FirstName = doctorregisterVM.DoctorFirstName,
                LastName = doctorregisterVM.DoctorLastName,
                Email = doctorregisterVM.DoctorEmailAddress,
                UserName = doctorregisterVM.DoctorEmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, doctorregisterVM.DoctorPassword);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Doctor);
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> Check()
        //{

        //    var count = await _service.GetAllAsync();
        //    var cn = count.Count();
        //    ViewBag.dpres = cn;

        //    return View();
        //}

        //public async Task<IActionResult> Check()
        //{

        //    var count = await _service.GetAllAsync();
        //    var cn = count.Count();
        //    ViewBag.doctors = cn;

        //    return View();
        //}
        public void count()
        {
            ApplicationUser allcount = new ApplicationUser();
          


            //Pharmacy pharmacycount = new Pharmacy();
            //DeliveryPerson delpersoncount = new DeliveryPerson();
            var count = allcount.Id.ToList();
            //var dcount = count4.Email.ToList();
            //var phcount = pharmacycount.OwnerFirstName.ToList();
            //var delpscount = delpersoncount.FirstName.ToList();
            ViewBag.count = count.Count()-5;

          
          
        }

        //public IActionResult Check()
        //{
        //    count();
        //    return View();
        //}

        public IActionResult AdminDashboard()
        {

            return View();

        }


    }
}
