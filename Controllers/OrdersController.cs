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
    public class OrdersController : Controller
    {

        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            //string testemail = User.FindFirstValue(ClaimTypes.Name);
            //string useruserId = User.IsInRole(ClaimTypes.);

            var orders = await _service.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var ordersDropdownsData = await _service.GetOrdersDropdownsValues();


            ViewBag.AppUsers = new SelectList(ordersDropdownsData.AppUsers, "UserName", "Email");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrdersVM digitalPrescription)
        {
            if (!ModelState.IsValid)
            {
                var ordersDropdownsData = await _service.GetOrdersDropdownsValues();


                ViewBag.AppUsers = new SelectList(ordersDropdownsData.AppUsers, "UserName", "Email");


                return View(digitalPrescription);
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _service.AddNewOrderAsync(digitalPrescription, userId, userEmailAddress);


            //await _service.StoreDigitalPrescriptionAsync(userId, userEmailAddress);

            return RedirectToAction(nameof(Index));
        }

        //GET: DigitalPrescriptions/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await _service.GetOrdersByIdAsync(id);
            return View(orderDetails);
        }

        //GET: DigitalPrescriptions/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var orderDetails = await _service.GetOrdersByIdAsync(id);
            if (orderDetails == null) return View("NotFound");

            var response = new OrdersVM()
            {
                Id = orderDetails.Id,
                CustomerUserId = orderDetails.CustomerUserEmailTag,
                customerFirstName = orderDetails.customerFirstName,
                customerLastName = orderDetails.customerLastName,
                //DrugProductCategory = data.DrugProductCategory,
                item1 = orderDetails.item1,
                item2 = orderDetails.item2,
                item3 = orderDetails.item3,
                item4 = orderDetails.item4,
                item5 = orderDetails.item5,
                item6 = orderDetails.item6,
                numberofUnits1 = orderDetails.numberofUnits1,
                numberofUnits2 = orderDetails.numberofUnits2,
                numberofUnits3 = orderDetails.numberofUnits3,
                numberofUnits4 = orderDetails.numberofUnits4,
                numberofUnits5 = orderDetails.numberofUnits5,
                numberofUnits6 = orderDetails.numberofUnits6,

                unitPrice1 = orderDetails.unitPrice1,
                unitPrice2 = orderDetails.unitPrice2,
                unitPrice3 = orderDetails.unitPrice3,
                unitPrice4 = orderDetails.unitPrice4,
                unitPrice5 = orderDetails.unitPrice5,
                unitPrice6 = orderDetails.unitPrice6,
                price1 = orderDetails.price1,
                price2 = orderDetails.price2,
                price3 = orderDetails.price3,
                price4 = orderDetails.price4,
                price5 = orderDetails.price5,
                price6 = orderDetails.price6,
                customerDeliveryContactNumber = orderDetails.customerDeliveryContactNumber

            };

            var digitalPrescriptionDropdownsData = await _service.GetOrdersDropdownsValues();
            ViewBag.AppUsers = new SelectList(digitalPrescriptionDropdownsData.AppUsers, "UserName", "Email");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrdersVM digitalPrescription)
        {
            if (id != digitalPrescription.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {

                var digitalPrescriptionDropdownsData = await _service.GetOrdersDropdownsValues();

                ViewBag.AppUsers = new SelectList(digitalPrescriptionDropdownsData.AppUsers, "UserName", "Email");

                return View(digitalPrescription);
            }
            string userupdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userupdateEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _service.UpdateOrderAsync(digitalPrescription, userupdateId, userupdateEmailAddress);
            return RedirectToAction(nameof(Index));
        }


        //DigitalPrescription/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var digitalPrescriptionDetails = await _service.GetOrdersByIdAsync(id);
            if (digitalPrescriptionDetails == null) return View("NotFound");

            return View(digitalPrescriptionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var digitalPrescriptionDetails = await _service.GetOrdersByIdAsync(id);
            if (digitalPrescriptionDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ConfirmedOrderUser(string searchString)
        {
            var allOrders = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allOrders.Where(n => string.Equals(n.CustomerUserEmailTag, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.customerDeliveryContactNumber, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var confirmedOrderCount = filteredResultNew.Count();
                ViewBag.confirmedOrderCount = confirmedOrderCount;
                return View("Index", filteredResultNew);
            }

            return View("Index", allOrders);
        }
        public async Task<IActionResult> SenttoDeliveryPerson(string searchString)
        {
            var allDigitalPrescriptions = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allDigitalPrescriptions.Where(n => string.Equals(n.DeliveryPersonUserEmailTag, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.customerDeliveryContactNumber, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var confirmedDeliverOrderCount = filteredResultNew.Count();
                ViewBag.confirmedDeliverOrderCount = confirmedDeliverOrderCount;
                
                return View("Index", filteredResultNew);
            }

            return View("Index", allDigitalPrescriptions);
        }


    }
}
