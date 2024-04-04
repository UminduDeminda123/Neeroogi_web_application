using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data.Base;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public class OrdersService : EntityBaseRepository<Orders>, IOrdersService

    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context) : base(context)

        {

            _context = context;

        }
        public async Task<List<Orders>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.AppUser).ToListAsync();
            //var users = await _context.Users.Include(n => n.Email).ToListAsync();
            //var useremail = users;


            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.AppUserId == userId).ToList();

                //if (userRole == "User")
                //{
                //    //orders = orders.Where(n => n.CustomerUserEmail == userId).ToList();
                //    orders = orders.Where(n => string.Equals(n.CustomerUserEmail, userId, StringComparison.CurrentCultureIgnoreCase)).ToList();


                //    //return orders;
                //}
                //orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        //public async Task StoreDigitalPrescriptionAsync(string userId, string userEmailAddress)
        //{
        //    var dprescription = new DigitalPrescription()
        //    {
        //        UserDoctorId = userId,
        //        Email = userEmailAddress
        //    };
        //    await _context.DigitalPrescriptions.AddAsync(dprescription);
        //    await _context.SaveChangesAsync();

        //}



        public async Task AddNewOrderAsync(OrdersVM data, string userId, string userEmailAddress)
        {
            var newDigitalPrescription = new Orders()
            {

                AppUserId = userId,
                Email = userEmailAddress,
                CustomerUserEmailTag = data.CustomerUserId,
                //PharmacyUserEmail = data.PharmacyUserId,
                customerFirstName = data.customerFirstName,
                customerLastName = data.customerLastName,
                //DrugProductCategory = data.DrugProductCategory,
                DateofIssue = data.DateofIssue,
                item1 = data.item1,
                item2 = data.item2,
                item3 = data.item3,
                item4 = data.item4,
                item5 = data.item5,
                item6 = data.item6,
                numberofUnits1 = data.numberofUnits1,
                numberofUnits2 = data.numberofUnits2,
                numberofUnits3 = data.numberofUnits3,
                numberofUnits4 = data.numberofUnits4,
                numberofUnits5 = data.numberofUnits5,
                numberofUnits6 = data.numberofUnits6,
                //price1 = data.price1,
                //price2 = data.price2,
                //price3 = data.price3,
                //price4 = data.price4,
                //price5 = data.price5,
                //price6 = data.price6,
                unitPrice1 = data.unitPrice1,
                unitPrice2 = data.unitPrice2,
                unitPrice3 = data.unitPrice3,
                unitPrice4 = data.unitPrice4,
                unitPrice5 = data.unitPrice5,
                unitPrice6 = data.unitPrice6,
                price1 = data.unitPrice1 * data.numberofUnits1,
                price2 = data.unitPrice2 * data.numberofUnits2,
                price3 = data.unitPrice3 * data.numberofUnits3,
                price4 = data.unitPrice4 * data.numberofUnits4,
                price5 = data.unitPrice5 * data.numberofUnits5,
                price6 = data.unitPrice6 * data.numberofUnits6,
                Total = (data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6),
                GrandTotal = ((data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6)) / 100 * 10 + ((data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6)),
                customerDeliveryContactNumber = data.customerDeliveryContactNumber

            };
            await _context.Orders.AddAsync(newDigitalPrescription);
            await _context.SaveChangesAsync();

            //Add Digital Prescriptions - Pharmacies
            //foreach (var pharmacyId in data.PharmacyIds)
            //{
            //    var newDigitalPrescriptionsPharmacies = new DigitalPrescription_Pharmacy()
            //    {
            //        DigitalPrescriptionId = newDigitalPrescription.Id,
            //        PharmacyId = pharmacyId
            //    };
            //    await _context.DigitalPrescriptionsPharmacies.AddAsync(newDigitalPrescriptionsPharmacies);
            //}
            await _context.SaveChangesAsync();
        }

        public async Task<Orders> GetOrdersByIdAsync(int id)
        {
            var digitalPrescriptionDetails = await _context.Orders
             //.Include(d => d.Doctor)
             //.Include(dp => dp.DigitalPrescriptons_Pharmacies).ThenInclude(p => p.Pharmacy)
             .FirstOrDefaultAsync(n => n.Id == id);

            return digitalPrescriptionDetails;
        }

        public async Task<OrdersDropdownsVM> GetOrdersDropdownsValues()
        {
            var response = new OrdersDropdownsVM()
            {
                AppUsers = await _context.Users.OrderBy(n => n.UserName).ToListAsync()
            };

            return response;
        }
        public async Task UpdateOrderAsync(OrdersVM data, string userupdateId, string userupdateEmailAddress)
        {
            var dbDigitalPrescription = await _context.Orders.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbDigitalPrescription != null)
            {
                dbDigitalPrescription.AppUserId = userupdateId;
                dbDigitalPrescription.Email = userupdateEmailAddress;
                dbDigitalPrescription.DeliveryPersonUserEmailTag = data.DeliveryPersonAppUserId;
                //PharmacyUserEmail = data.PharmacyUserId,
                dbDigitalPrescription.customerFirstName = data.customerFirstName;
                dbDigitalPrescription.customerLastName = data.customerLastName;
                //DrugProductCategory = data.DrugProductCategory,
                dbDigitalPrescription.DateofIssue = data.DateofIssue;
                dbDigitalPrescription.item1 = data.item1;
                dbDigitalPrescription.item2 = data.item2;
                dbDigitalPrescription.item3 = data.item3;
                dbDigitalPrescription.item4 = data.item4;
                dbDigitalPrescription.item5 = data.item5;
                dbDigitalPrescription.item6 = data.item6;
                dbDigitalPrescription.numberofUnits1 = data.numberofUnits1;
                dbDigitalPrescription.numberofUnits2 = data.numberofUnits2;
                dbDigitalPrescription.numberofUnits3 = data.numberofUnits3;
                dbDigitalPrescription.numberofUnits4 = data.numberofUnits4;
                dbDigitalPrescription.numberofUnits5 = data.numberofUnits5;
                dbDigitalPrescription.numberofUnits6 = data.numberofUnits6;
                //price1 = data.price1,
                //price2 = data.price2,
                //price3 = data.price3,
                //price4 = data.price4,
                //price5 = data.price5,
                //price6 = data.price6,
                dbDigitalPrescription.unitPrice1 = data.unitPrice1;
                dbDigitalPrescription.unitPrice2 = data.unitPrice2;
                dbDigitalPrescription.unitPrice3 = data.unitPrice3;
                dbDigitalPrescription.unitPrice4 = data.unitPrice4;
                dbDigitalPrescription.unitPrice5 = data.unitPrice5;
                dbDigitalPrescription.unitPrice6 = data.unitPrice6;
                dbDigitalPrescription.price1 = data.unitPrice1 * data.numberofUnits1;
                dbDigitalPrescription.price2 = data.unitPrice2 * data.numberofUnits2;
                dbDigitalPrescription.price3 = data.unitPrice3 * data.numberofUnits3;
                dbDigitalPrescription.price4 = data.unitPrice4 * data.numberofUnits4;
                dbDigitalPrescription.price5 = data.unitPrice5 * data.numberofUnits5;
                dbDigitalPrescription.price6 = data.unitPrice6 * data.numberofUnits6;
                dbDigitalPrescription.Total = (data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6);
                dbDigitalPrescription.GrandTotal = ((data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6)) / 100 * 10 + ((data.unitPrice1 * data.numberofUnits1) + (data.unitPrice2 * data.numberofUnits2) + (data.unitPrice3 * data.numberofUnits3) + (data.unitPrice4 * data.numberofUnits4) + (data.unitPrice5 * data.numberofUnits5) + (data.unitPrice6 * data.numberofUnits6));
                dbDigitalPrescription.customerDeliveryContactNumber = data.customerDeliveryContactNumber;

                await _context.SaveChangesAsync();
            }

            //Remove Existing Pharmacies
            //var existingPharmaciesDb = _context.DigitalPrescriptionsPharmacies.Where(n => n.PharmacyId == data.Id).ToList();
            //_context.DigitalPrescriptionsPharmacies.RemoveRange(existingPharmaciesDb);
            await _context.SaveChangesAsync();

            //Add Digital Prescription Pharmacies
            //foreach (var pharmacyId in data.PharmacyIds)
            //{
            //    var newpharmacyDigitalPrescription = new DigitalPrescription_Pharmacy()
            //    {
            //        DigitalPrescriptionId = data.Id,
            //        PharmacyId = pharmacyId
            //    };
            //    await _context.DigitalPrescriptionsPharmacies.AddAsync(newpharmacyDigitalPrescription);
            //}
            await _context.SaveChangesAsync();
        }


    }
}
