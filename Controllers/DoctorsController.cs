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
    [Authorize(Roles = UserRoles.Admin)]
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _service;

        public DoctorsController(IDoctorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allDoctors = await _service.GetAllAsync();
            return View(allDoctors);
        }
        //Get: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FirstName,LastName,FullName,ContactNumber,Birthday,NIC,GraduatedUniversity,GraduatedYear,Degree,DegreeSpecialization,RegNumber,EmergencyContactNumber,IdpicturefrontURL,IdpicturebackURL,OfficialIDFrontPictureURL,OfficialIDBackPictureURL,VerifiedCertificateURL,SpecialReport")] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            await _service.AddAsync(doctor);
            return RedirectToAction(nameof(Index));
        }

        //Get Request
        //Doctors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var doctorDetails = await _service.GetByIdAsync(id);
            if (doctorDetails == null) return View("NotFound");
            return View(doctorDetails); 
            
        }

        //Doctors/Update
        public async Task<IActionResult> Edit(int id)
        {
            var doctorDetails = await _service.GetByIdAsync(id);
            if (doctorDetails == null) return View("NotFound");

            return View(doctorDetails);
        } 

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FirstName,LastName,FullName,ContactNumber,Birthday,NIC,GraduatedUniversity,GraduatedYear,Degree,DegreeSpecialization,RegNumber,EmergencyContactNumber,IdpicturefrontURL,IdpicturebackURL,OfficialIDFrontPictureURL,OfficialIDBackPictureURL,VerifiedCertificateURL,SpecialReport")] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            await _service.UpdateAsync(id,doctor);
            return RedirectToAction(nameof(Index));
        }
        //Doctors/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var doctorDetails = await _service.GetByIdAsync(id);
            if (doctorDetails == null) return View("NotFound");

            return View(doctorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorDetails = await _service.GetByIdAsync(id);
            if (doctorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
