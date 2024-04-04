using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data;
using Neerogilksample.Data.Services;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    [Authorize]
    public class DigitalPrescriptionsController : Controller
    {

        private readonly IDigitalPrescriptionsService _service;

        public DigitalPrescriptionsController(IDigitalPrescriptionsService service)
        {
            _service = service;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var alldigitalPrescriptions = await _service.GetAllAsync(n => n.Doctor);
        //    return View(alldigitalPrescriptions);
        //}

        public async Task<IActionResult> ConfirmedOrders()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            //string testemail = User.FindFirstValue(ClaimTypes.Name);
            //string useruserId = User.IsInRole(ClaimTypes.);

            var orders = await _service.GetDigitalPrescriptionByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            //string testemail = User.FindFirstValue(ClaimTypes.Name);
            //string useruserId = User.IsInRole(ClaimTypes.);

            var orders = await _service.GetDigitalPrescriptionByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        //Completing Creating a Digital Prescription
        //public async Task<IActionResult> CompleteCreatingDigitalPrescription()
        //{

        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        //    await _service.StoreDigitalPrescriptionAsync(userId, userEmailAddress);


        //    return View("OrderCompleted");
        //}

        //Get: DigitalPrescription/Create
        public async Task<IActionResult> Create()
        {
            var digitalPrescriptionDropdownsData = await _service.GetNewDigitalPrescriptionDropdownsValues();

            ViewBag.Doctors = new SelectList(digitalPrescriptionDropdownsData.Doctors, "Id", "FullName");
            ViewBag.Pharmacies = new SelectList(digitalPrescriptionDropdownsData.Pharmacies, "Id", "PharmacyName");
            ViewBag.Users = new SelectList(digitalPrescriptionDropdownsData.Users, "UserName", "Email");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDigitalPrescriptionVM digitalPrescription)
        {
            if (!ModelState.IsValid)
            {
                var digitalPrescriptionDropdownsData = await _service.GetNewDigitalPrescriptionDropdownsValues();

                ViewBag.Doctors = new SelectList(digitalPrescriptionDropdownsData.Doctors, "Id", "FullName");
                ViewBag.Pharmacies = new SelectList(digitalPrescriptionDropdownsData.Pharmacies, "Id", "PharmacyName");
                ViewBag.Users = new SelectList(digitalPrescriptionDropdownsData.Users, "UserName", "Email");


                return View(digitalPrescription);
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _service.AddNewDigitalPrescriptionAsync(digitalPrescription, userId, userEmailAddress);


            //await _service.StoreDigitalPrescriptionAsync(userId, userEmailAddress);

            return RedirectToAction(nameof(Index));
        }

        //GET: DigitalPrescriptions/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var digitalPrescriptionDetails = await _service.GetDigitalPrescriptionByIdAsync(id);
            //var deliveryLinklong = digitalPrescriptionDetails.Longtitude;
            //var deliveryLinklatt = digitalPrescriptionDetails.Lattiude;
            //ViewBag.Long = deliveryLinklong;
            //ViewBag.Latt = deliveryLinklatt;



            return View(digitalPrescriptionDetails);
        }

        //GET: DigitalPrescriptions/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var digitalPrescriptionDetails = await _service.GetDigitalPrescriptionByIdAsync(id);
            if (digitalPrescriptionDetails == null) return View("NotFound");

            var response = new NewDigitalPrescriptionVM()
            {
                Id = digitalPrescriptionDetails.Id,
                UserId = digitalPrescriptionDetails.CustomerUserEmail,
                PatientName = digitalPrescriptionDetails.PatientName,
                Age = digitalPrescriptionDetails.Age,
                //DrugProductCategory = data.DrugProductCategory,
                PatientAddress = digitalPrescriptionDetails.PatientAddress,
                BirthDay = digitalPrescriptionDetails.BirthDay,
                Mealperiod = digitalPrescriptionDetails.Mealperiod,
                Description = digitalPrescriptionDetails.Description,
                Dateofissue = digitalPrescriptionDetails.Dateofissue,
                Signature = digitalPrescriptionDetails.Signature,
                DoctorId = digitalPrescriptionDetails.DoctorId,
                ContactNumber = digitalPrescriptionDetails.ContactNumber,
                ExpirationDate = digitalPrescriptionDetails.ExpirationDate,
                Seal = digitalPrescriptionDetails.Seal,
                //1
                Medicine1 = digitalPrescriptionDetails.Medicine1,
                Dosage1 = digitalPrescriptionDetails.Dosage1,
                Medides1 = digitalPrescriptionDetails.Medides1,
                //2
                Medicine2 = digitalPrescriptionDetails.Medicine2,
                Dosage2 = digitalPrescriptionDetails.Dosage2,
                Medides2 = digitalPrescriptionDetails.Medides2,
                //3
                Medicine3 = digitalPrescriptionDetails.Medicine3,
                Dosage3 = digitalPrescriptionDetails.Dosage3,
                Medides3 = digitalPrescriptionDetails.Medides3,
                //4
                Medicine4 = digitalPrescriptionDetails.Medicine4,
                Dosage4 = digitalPrescriptionDetails.Dosage4,
                Medides4 = digitalPrescriptionDetails.Medides4,
                //5

                Medicine5 = digitalPrescriptionDetails.Medicine5,
                Dosage5 = digitalPrescriptionDetails.Dosage5,
                Medides5 = digitalPrescriptionDetails.Medides5,
                //6

                Medicine6 = digitalPrescriptionDetails.Medicine6,
                Dosage6 = digitalPrescriptionDetails.Dosage6,
                Medides6 = digitalPrescriptionDetails.Medides6,
                PharmacyIds = digitalPrescriptionDetails.DigitalPrescriptons_Pharmacies.Select(n => n.PharmacyId).ToList()


            };

            var digitalPrescriptionDropdownsData = await _service.GetNewDigitalPrescriptionDropdownsValues();
            ViewBag.Doctors = new SelectList(digitalPrescriptionDropdownsData.Doctors, "Id", "FullName");
            ViewBag.Pharmacies = new SelectList(digitalPrescriptionDropdownsData.Pharmacies, "Id", "PharmacyName");
            ViewBag.Users = new SelectList(digitalPrescriptionDropdownsData.Users, "UserName", "Email");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDigitalPrescriptionVM digitalPrescription)
        {
            if (id != digitalPrescription.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {

                var digitalPrescriptionDropdownsData = await _service.GetNewDigitalPrescriptionDropdownsValues();

                ViewBag.Doctors = new SelectList(digitalPrescriptionDropdownsData.Doctors, "Id", "FullName");
                ViewBag.Pharmacies = new SelectList(digitalPrescriptionDropdownsData.Pharmacies, "Id", "PharmacyName");
                ViewBag.Users = new SelectList(digitalPrescriptionDropdownsData.Users, "UserName", "Email");

                return View(digitalPrescription);
            }
            string userupdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userupdateEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _service.UpdateDigitalPrescriptionAsync(digitalPrescription, userupdateId, userupdateEmailAddress);
            return RedirectToAction(nameof(Index));
        }


        //DigitalPrescription/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var digitalPrescriptionDetails = await _service.GetDigitalPrescriptionByIdAsync(id);
            if (digitalPrescriptionDetails == null) return View("NotFound");

            return View(digitalPrescriptionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var digitalPrescriptionDetails = await _service.GetDigitalPrescriptionByIdAsync(id);
            if (digitalPrescriptionDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allDigitalPrescriptions = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allDigitalPrescriptions.Where(n => string.Equals(n.CustomerUserEmail, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var digitalPresCount = filteredResultNew.Count();
                ViewBag.DigitalPresCount = digitalPresCount;
                return View("Index", filteredResultNew);
            }

            return View("Index", allDigitalPrescriptions);
        }


        public async Task<IActionResult> ReceivedOrders(string searchString)
        {
            var allDigitalPrescriptions = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allDigitalPrescriptions.Where(n => string.Equals(n.PharmacyUserEmail, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var orderCount = filteredResultNew.Count();
                ViewBag.Count = orderCount;
                return View("Index", filteredResultNew);
            }

            return View("Index", allDigitalPrescriptions);
        }

        public async Task<IActionResult> ConfirmedOrderUser(string searchString)
        {
            var allDigitalPrescriptions = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allDigitalPrescriptions.Where(n => string.Equals(n.PharmacyUserEmail, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allDigitalPrescriptions);
        }



public async Task<IActionResult> Check()
        {
           
            var count = await _service.GetAllAsync();
            var cn = count.Count();
            ViewBag.dpres = cn;
          
            return View();
        }

    }
}
