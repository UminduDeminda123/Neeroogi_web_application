using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PharmaciesController : Controller
    {

        
        private readonly IPharmaciesService _service;

        public PharmaciesController(IPharmaciesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPharmacies = await _service.GetAllAsync();
            return View(allPharmacies);
        }

        //Get: Pharmacies/Create
        public async Task<IActionResult> Create()
        {
            var pharmaciesDropdownsData = await _service.GetNewPharmacyDropdownsValues();

            ViewBag.Doctors = new SelectList(pharmaciesDropdownsData.Doctors, "Id", "FullName");
            ViewBag.DeliveryPersons = new SelectList(pharmaciesDropdownsData.DeliveryPersons, "Id", "FullName");
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewPharmacyVM pharmacy)
        {
            if (!ModelState.IsValid)
            {
                var pharmaciesDropdownsData = await _service.GetNewPharmacyDropdownsValues();

                ViewBag.Doctors = new SelectList(pharmaciesDropdownsData.Doctors, "Id", "FullName");
                ViewBag.DeliveryPersons = new SelectList(pharmaciesDropdownsData.DeliveryPersons, "Id", "FullName");


                return View(pharmacy);
            }

            await _service.AddNewPharmacyAsync(pharmacy);
            return RedirectToAction(nameof(Index));
        }

        //GET: DigitalPrescriptions/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacyDetails = await _service.GetPharmacyByIdAsync(id);
            return View(pharmacyDetails);
        }

        //GET: DigitalPrescriptions/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var pharmacyDetails = await _service.GetPharmacyByIdAsync(id);
            if (pharmacyDetails == null) return View("NotFound");

            var response = new NewPharmacyVM()
            {
                Logo = pharmacyDetails.Logo,
                OwnerIdpicturefrontURL = pharmacyDetails.OwnerIdpicturefrontURL,
                OwnerIdpicturebackURL = pharmacyDetails.OwnerIdpicturebackURL,
                PharmacyRegistrationCertificatePicture = pharmacyDetails.PharmacyRegistrationCertificatePicture,
                Description = pharmacyDetails.Description,
                OwnersLicenseIDPicture = pharmacyDetails.OwnersLicenseIDPicture,
                PharmacyAddress = pharmacyDetails.PharmacyAddress,
                PharmacyName = pharmacyDetails.PharmacyName,
                PharmacyRegisteredNumber = pharmacyDetails.PharmacyRegisteredNumber,
                OwnerFirstName = pharmacyDetails.OwnerFirstName,
                OwnerLastName = pharmacyDetails.OwnerLastName,
                OwnerFullName = pharmacyDetails.OwnerFullName,
                OwnersNIC = pharmacyDetails.OwnersNIC,
                WhatsAppNumber = pharmacyDetails.WhatsAppNumber,
                RegistrationDate = pharmacyDetails.RegistrationDate,
                GeoCoordinatesGoogleLocation = pharmacyDetails.GeoCoordinatesGoogleLocation,
                ContactNumber = pharmacyDetails.ContactNumber,
                EmergencyContactNumber = pharmacyDetails.EmergencyContactNumber

            };

            var pharmacyDropdownsData = await _service.GetNewPharmacyDropdownsValues();
            ViewBag.Doctors = new SelectList(pharmacyDropdownsData.Doctors, "Id", "FullName");
            ViewBag.DeliveryPersons = new SelectList(pharmacyDropdownsData.DeliveryPersons, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPharmacyVM pharmacy)
        {
            if (id != pharmacy.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var pharmacyDropdownsData = await _service.GetNewPharmacyDropdownsValues();
                ViewBag.Doctors = new SelectList(pharmacyDropdownsData.Doctors, "Id", "FullName");
                ViewBag.DeliveryPersons = new SelectList(pharmacyDropdownsData.DeliveryPersons, "Id", "FullName");


                return View(pharmacy);
            }

            await _service.UpdatePharmacyAsync(pharmacy);
            return RedirectToAction(nameof(Index));
        }
        //Pharmacies/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);
            if (pharmacyDetails == null) return View("NotFound");

            return View(pharmacyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);
            if (pharmacyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FindPharmacy()
        {
            var allPharmacies = await _service.GetAllAsync();

            return View(allPharmacies);
        }
      
      
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPharmacies = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allPharmacies.Where(n => string.Equals(n.LocatedNearsetCity, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.PharmacyName, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allPharmacies);
        }

    }
}
