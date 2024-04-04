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
    public class DigitalPrescriptionService : EntityBaseRepository<DigitalPrescription>, IDigitalPrescriptionsService

    {
        private readonly AppDbContext _context;
        public DigitalPrescriptionService(AppDbContext context) : base(context)

        {

            _context = context;

        }
        public async Task<List<DigitalPrescription>> GetDigitalPrescriptionByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.DigitalPrescriptions.Include(n => n.UserDoctor).ToListAsync();
            //var users = await _context.Users.Include(n => n.Email).ToListAsync();
            //var useremail = users;
            

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserDoctorId == userId).ToList();

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
        
        

        public async Task AddNewDigitalPrescriptionAsync(NewDigitalPrescriptionVM data, string userId, string userEmailAddress)
        {
            var newDigitalPrescription = new DigitalPrescription()
            {
                
                UserDoctorId = userId,
                Email = userEmailAddress,
                CustomerUserEmail = data.UserId,
                //PharmacyUserEmail = data.PharmacyUserId,
                PatientName = data.PatientName,
                Age = data.Age,
                //DrugProductCategory = data.DrugProductCategory,
                PatientAddress = data.PatientAddress,
                BirthDay = data.BirthDay,
                Mealperiod = data.Mealperiod,
                Description = data.Description,
                Dateofissue = data.Dateofissue,
                Signature = data.Signature,
                DoctorId = data.DoctorId,
                ContactNumber = data.ContactNumber,
                ExpirationDate = data.ExpirationDate,
                Seal = data.Seal,
                //1
                Medicine1 = data.Medicine1,
                Dosage1 = data.Dosage1,
                Medides1 = data.Medides1,
                //2
                Medicine2 = data.Medicine2,
                Dosage2 = data.Dosage2,
                Medides2 = data.Medides2,
                //3
                Medicine3 = data.Medicine3,
                Dosage3 = data.Dosage3,
                Medides3 = data.Medides3,
                //4
                Medicine4 = data.Medicine4,
                Dosage4 = data.Dosage4,
                Medides4 = data.Medides4,
                //5

                Medicine5 = data.Medicine5,
                Dosage5 = data.Dosage5,
                Medides5 = data.Medides5,
                //6
                
                Medicine6 = data.Medicine6,
                Dosage6 = data.Dosage6,
                Medides6 = data.Medides6,



            };
            await _context.DigitalPrescriptions.AddAsync(newDigitalPrescription);
            await _context.SaveChangesAsync();

            //Add Digital Prescriptions - Pharmacies
            foreach (var pharmacyId in data.PharmacyIds)
            {
                var newDigitalPrescriptionsPharmacies = new DigitalPrescription_Pharmacy()
                {
                    DigitalPrescriptionId = newDigitalPrescription.Id,
                    PharmacyId = pharmacyId
                };
                await _context.DigitalPrescriptionsPharmacies.AddAsync(newDigitalPrescriptionsPharmacies);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<DigitalPrescription> GetDigitalPrescriptionByIdAsync(int id)
        {
            var digitalPrescriptionDetails = await _context.DigitalPrescriptions
             .Include(d => d.Doctor)
             .Include(dp => dp.DigitalPrescriptons_Pharmacies).ThenInclude(p => p.Pharmacy)
             .FirstOrDefaultAsync(n => n.Id == id);

            return digitalPrescriptionDetails;
        }

        public async Task<NewDigitalPrescriptionDropdownsVM> GetNewDigitalPrescriptionDropdownsValues()
        {
            var response = new NewDigitalPrescriptionDropdownsVM()
            {

                Doctors = await _context.Doctors.OrderBy(n => n.FullName).ToListAsync(),
                Pharmacies = await _context.Pharmacies.OrderBy(n => n.PharmacyName).ToListAsync(),
                Users = await _context.Users.OrderBy(n => n.UserName).ToListAsync()
            };

            return response;
        }
        public async Task UpdateDigitalPrescriptionAsync(NewDigitalPrescriptionVM data, string userupdateId, string userupdateEmailAddress)
        {
            var dbDigitalPrescription = await _context.DigitalPrescriptions.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbDigitalPrescription != null)
            {
                dbDigitalPrescription.Email = userupdateEmailAddress;
                dbDigitalPrescription.UserDoctorId = userupdateId;
                dbDigitalPrescription.PharmacyUserEmail = data.PharmacyUserId;
                dbDigitalPrescription.PatientName = data.PatientName;
                dbDigitalPrescription.Age = data.Age;
                //DrugProductCategory = data.DrugProductCategory,
                dbDigitalPrescription.PatientAddress = data.PatientAddress;
                dbDigitalPrescription.BirthDay = data.BirthDay;
                dbDigitalPrescription.Mealperiod = data.Mealperiod;
                dbDigitalPrescription.Description = data.Description;
                dbDigitalPrescription.Dateofissue = data.Dateofissue;
                dbDigitalPrescription.Signature = data.Signature;
                dbDigitalPrescription.DoctorId = data.DoctorId;
                dbDigitalPrescription.ContactNumber = data.ContactNumber;
                dbDigitalPrescription.ExpirationDate = data.ExpirationDate;
                dbDigitalPrescription.Seal = data.Seal;
                dbDigitalPrescription.Location = data.Location;
                dbDigitalPrescription.Lattiude = data.Lattiude;
                dbDigitalPrescription.Longtitude = data.Longtitude;
                dbDigitalPrescription.City = data.City;
                //1
                dbDigitalPrescription.Medicine1 = data.Medicine1;
                dbDigitalPrescription.Dosage1 = data.Dosage1;
                dbDigitalPrescription.Medides1 = data.Medides1;
                //2
                dbDigitalPrescription.Medicine2 = data.Medicine2;
                dbDigitalPrescription.Dosage2 = data.Dosage2;
                dbDigitalPrescription.Medides2 = data.Medides2;
                //3
                dbDigitalPrescription.Medicine3 = data.Medicine3;
                dbDigitalPrescription.Dosage3 = data.Dosage3;
                dbDigitalPrescription.Medides3 = data.Medides3;
                //4
                dbDigitalPrescription.Medicine4 = data.Medicine4;
                dbDigitalPrescription.Dosage4 = data.Dosage4;
                dbDigitalPrescription.Medides4 = data.Medides4;
                //5

                dbDigitalPrescription.Medicine5 = data.Medicine5;
                dbDigitalPrescription.Dosage5 = data.Dosage5;
                dbDigitalPrescription.Medides5 = data.Medides5;
                //6

                dbDigitalPrescription.Medicine6 = data.Medicine6;
                dbDigitalPrescription.Dosage6 = data.Dosage6;
                dbDigitalPrescription.Medides6 = data.Medides6;
             
                await _context.SaveChangesAsync();
            }

            //Remove Existing Pharmacies
            var existingPharmaciesDb = _context.DigitalPrescriptionsPharmacies.Where(n => n.PharmacyId == data.Id).ToList();
            _context.DigitalPrescriptionsPharmacies.RemoveRange(existingPharmaciesDb);
            await _context.SaveChangesAsync();

            //Add Digital Prescription Pharmacies
            foreach (var pharmacyId in data.PharmacyIds)
            {
                var newpharmacyDigitalPrescription = new DigitalPrescription_Pharmacy()
                {
                    DigitalPrescriptionId = data.Id,
                    PharmacyId = pharmacyId
                };
                await _context.DigitalPrescriptionsPharmacies.AddAsync(newpharmacyDigitalPrescription);
            }
            await _context.SaveChangesAsync();
        }


    }
}
