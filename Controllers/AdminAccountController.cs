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
    public class AdminAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IDoctorsService _service;
        private readonly IOrdersService _service1;
        private readonly IPharmaciesService _service2;
        private readonly IDeliveryPersonsService _service3;
        private readonly IDigitalPrescriptionsService _service4;

        public AdminAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IDoctorsService service, IOrdersService service1, IPharmaciesService service2, IDeliveryPersonsService service3, IDigitalPrescriptionsService service4)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
            _service4 = service4;


        }
        public IActionResult Login() => View(new AdminLoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM doctorloginVM)
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
                        return RedirectToAction("AdminDashboard", "AdminAccount");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(doctorloginVM);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(doctorloginVM);
        }
        public IActionResult Register() => View(new AdminRegisterVM());
        [HttpPost]
        public async Task<IActionResult> Register(AdminRegisterVM doctorregisterVM)
        {
            if (!ModelState.IsValid) return View(doctorregisterVM);
            var user = await _userManager.FindByEmailAsync(doctorregisterVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(doctorregisterVM);
            }
            var newUser = new ApplicationUser()
            {
                FirstName = doctorregisterVM.FirstName,
                LastName = doctorregisterVM.LastName,
                Email = doctorregisterVM.EmailAddress,
                UserName = doctorregisterVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, doctorregisterVM.Password);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        //public IActionResult AdminDashboard()
        //{

        //    return View();

        //}


        public async Task<IActionResult> AdminDashboard()
        {
            //Doctor Count
            var count = await _service.GetAllAsync();
            var cn = count.Count();
            ViewBag.doctorscount = cn;

            //Orders Count

            var ordercount = await _service1.GetAllAsync();
            var ordersn = ordercount.Count();
            ViewBag.orderscount = ordersn;

            //Pharmacy Count
            var pharmacycount = await _service2.GetAllAsync();
            var pharmacycn = pharmacycount.Count();
            ViewBag.pharmacycount = pharmacycn;


            //Delvery Person Count
            var delpersoncount = await _service3.GetAllAsync();
            var delpersoncn = delpersoncount.Count();
            ViewBag.delpersoncount = delpersoncn;


            //Issued Digital Prescription Users
            var digiprescount = await _service4.GetAllAsync();
            var digiprescn = digiprescount.Count();
            ViewBag.digitalprescount = digiprescn;

         

            //All Users
            ApplicationUser allcount = new ApplicationUser();
                                
            var countall = allcount.Id.ToList();
          
            ViewBag.Allcount = countall.Count() - 5;

            //Customers
            var customercount = countall.Count() - (delpersoncn + pharmacycn + cn) -5;
            ViewBag.customers = customercount;

            //Orders - GrandTotal

            var orderTotal = await _service1.GetAllAsync();
            //var grand = orderTotal.includ



            Orders grandtot = new Orders();
            var Grand = ((decimal)grandtot.GrandTotal);
            //string grandTotal = grandtot.GrandTotal.




            //Orders - Total


            return View();
        }

    }
}
