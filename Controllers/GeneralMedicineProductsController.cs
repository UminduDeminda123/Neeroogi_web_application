using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class GeneralMedicineProductsController : Controller
    {

        private readonly IGeneralMedicineProductsService _service;

        public GeneralMedicineProductsController(IGeneralMedicineProductsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var generalMedicineProducts = await _service.GetAllAsync();
            return View(generalMedicineProducts);
        }

        //Get: GeneralMedicineProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProductPictureURL,Name,ManufacturedDate,ExpirationDate,ManufacturedCompanyName,DrugProductCategory")] GeneralMedicines product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get Request
        //GeneralMedicineProducts/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);

        }

        //GeneralMedicineProducts/Update
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductPictureURL,Name,ManufacturedDate,ExpirationDate,ManufacturedCompanyName,DrugProductCategory")] GeneralMedicines product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }
        //GeneralMedicineProducts/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
