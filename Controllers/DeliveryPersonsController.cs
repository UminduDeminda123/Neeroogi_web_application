using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data;
using Neerogilksample.Data.Services;
using Neerogilksample.Data.Static;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    [Authorize]
    public class DeliveryPersonsController : Controller
    {


        private readonly IDeliveryPersonsService _service;
      
        public DeliveryPersonsController(IDeliveryPersonsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allDeliveryPersons = await _service.GetAllAsync();
            return View(allDeliveryPersons);
        }
        //Get: DeliveryPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("ProfilePictureURL,FirstName,LastName,FullName,ContactNumber,Birthday,NIC,EmergencyContactNumber,IdpicturefrontURL,IdpicturebackURL,LicenseFrontPictureURL,LicenseBackPictureURL,PoliceReportsURL,ExpirationDate,ReceivedDateLicense")] DeliveryPerson deliveryPerson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(deliveryPerson);
        //    }
        //    await _service.AddAsync(deliveryPerson);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryPersonVM deliveryPerson)
        {
            //if (!ModelState.IsValid)
            //{
            //    var pharmaciesDropdownsData = await _service.GetNewPharmacyDropdownsValues();

            //    ViewBag.Doctors = new SelectList(pharmaciesDropdownsData.Doctors, "Id", "FullName");
            //    ViewBag.DeliveryPersons = new SelectList(pharmaciesDropdownsData.DeliveryPersons, "Id", "FullName");


            //    return View(pharmacy);
            //}

            await _service.AddDeliveryPersonAsync(deliveryPerson);
            return RedirectToAction(nameof(Index));
        }
        //Get Request
        //DeliveryPersons/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var deliveryPersonDetails = await _service.GetByIdAsync(id);
            if (deliveryPersonDetails == null) return View("NotFound");
            return View(deliveryPersonDetails);

        }

        ////DeliveryPersons/Update
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var deliveryPersonDetails = await _service.GetByIdAsync(id);
        //    if (deliveryPersonDetails == null) return View("NotFound");

        //    return View(deliveryPersonDetails);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FirstName,LastName,FullName,ContactNumber,Birthday,NIC,EmergencyContactNumber,IdpicturefrontURL,IdpicturebackURL,LicenseFrontPictureURL,LicenseBackPictureURL,PoliceReportsURL,ExpirationDate,ReceivedDateLicense")] DeliveryPerson deliveryPerson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(deliveryPerson);
        //    }
        //    await _service.UpdateAsync(id, deliveryPerson);
        //    return RedirectToAction(nameof(Index));
        //}


        //GET: DeliveryPersons/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var deliveryPersonDetails = await _service.GetDeliveryPersonByIdAsync(id);
            if (deliveryPersonDetails == null) return View("NotFound");

            var response = new DeliveryPersonVM()
            {
                ProfilePictureURL = deliveryPersonDetails.ProfilePictureURL,
                IdpicturefrontURL = deliveryPersonDetails.IdpicturefrontURL,
                IdpicturebackURL = deliveryPersonDetails.IdpicturebackURL,
                LicenseFrontPictureURL = deliveryPersonDetails.LicenseFrontPictureURL,
                LicenseBackPictureURL = deliveryPersonDetails.LicenseBackPictureURL,
                PoliceReportsURL = deliveryPersonDetails.PoliceReportsURL,
                appointedPharmacyEmail = deliveryPersonDetails.appointedPharmacyEmail,
                FirstName = deliveryPersonDetails.FirstName,
                LastName = deliveryPersonDetails.LastName,
                FullName = deliveryPersonDetails.FullName,
                Birthday = deliveryPersonDetails.Birthday,
                NIC = deliveryPersonDetails.NIC,
                ReceivedDateLicense = deliveryPersonDetails.ReceivedDateLicense,
                WhatsAppNumber = deliveryPersonDetails.WhatsAppNumber,
                ExpirationDate = deliveryPersonDetails.ExpirationDate,
                ContactNumber = deliveryPersonDetails.ContactNumber,
                EmergencyContactNumber = deliveryPersonDetails.EmergencyContactNumber

            };
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, DeliveryPersonVM deliveryPerson)
        {
            if (id != deliveryPerson.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                //var pharmacyDropdownsData = await _service.GetNewPharmacyDropdownsValues();
                //ViewBag.Doctors = new SelectList(pharmacyDropdownsData.Doctors, "Id", "FullName");
                //ViewBag.DeliveryPersons = new SelectList(pharmacyDropdownsData.DeliveryPersons, "Id", "FullName");


                return View(deliveryPerson);
            }

            await _service.UpdateDeliveryPersonsAsync(deliveryPerson);
            return RedirectToAction(nameof(Index));
        }
        //DeliveryPersons/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var deliveryPersonDetails = await _service.GetByIdAsync(id);
            if (deliveryPersonDetails == null) return View("NotFound");

            return View(deliveryPersonDetails);
        }
        [AllowAnonymous]
        public async Task<IActionResult> FindDeliveryPersons()
        {
            var allDeliveryPersons = await _service.GetAllAsync();

            return View(allDeliveryPersons);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryPersonDetails = await _service.GetByIdAsync(id);
            if (deliveryPersonDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> MyDeliveryPersons(string searchString)
        {
            var allDeliveryPersons = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allDeliveryPersons.Where(n => string.Equals(n.appointedPharmacyEmail, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.FirstName, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allDeliveryPersons);
        }
    }
}
