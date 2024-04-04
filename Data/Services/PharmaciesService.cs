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
    public class PharmaciesService : EntityBaseRepository<Pharmacy>, IPharmaciesService
    {
        private readonly AppDbContext _context;
        public PharmaciesService(AppDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<Pharmacy> GetPharmacyByIdAsync(int id)
        {
            var pharmacyDetails = await _context.Pharmacies
               
                .Include(dp => dp.Doctors_Pharmacies).ThenInclude(d => d.Doctor)
                .Include(pd => pd.DeliveryPersons_Pharmacies).ThenInclude(p => p.DeliveryPerson)
                .FirstOrDefaultAsync(n => n.Id == id);

            return pharmacyDetails;
        }

        public async Task<NewPharmacyDropdownsVM> GetNewPharmacyDropdownsValues()
        {
            var response = new NewPharmacyDropdownsVM()
            {
                Doctors = await _context.Doctors.OrderBy(n => n.FullName).ToListAsync(),
                DeliveryPersons = await _context.DeliveryPersons.OrderBy(d => d.FullName).ToListAsync()
              
      
            };

            return response;
        }

        public async Task AddNewPharmacyAsync(NewPharmacyVM data)
        {
            var newPharmacy = new Pharmacy()
            {
                Logo = data.Logo,
                OwnerIdpicturefrontURL = data.OwnerIdpicturefrontURL,
                OwnerIdpicturebackURL = data.OwnerIdpicturebackURL,
                LocatedNearsetCity = data.LocatedNearestCity,
                PharmacyRegistrationCertificatePicture = data.PharmacyRegistrationCertificatePicture,
                Description = data.Description,
                OwnersLicenseIDPicture = data.OwnersLicenseIDPicture,
                PharmacyAddress = data.PharmacyAddress,
                PharmacyName = data.PharmacyName,
                PharmacyRegisteredNumber = data.PharmacyRegisteredNumber,
                OwnerFirstName=data.OwnerFirstName,
                OwnerLastName=data.OwnerLastName,
                OwnerFullName = data.OwnerFullName,
                OwnersNIC=data.OwnersNIC,
                WhatsAppNumber = data.WhatsAppNumber,
                RegistrationDate = data.RegistrationDate,
                GeoCoordinatesGoogleLocation=data.GeoCoordinatesGoogleLocation,
                ContactNumber=data.ContactNumber,
                EmergencyContactNumber = data.EmergencyContactNumber


            };
            await _context.Pharmacies.AddAsync(newPharmacy);
            await _context.SaveChangesAsync();

            //Add Pharmacy Doctors
            foreach (var doctorId in data.DoctorIds)
            {
                var newDoctorPharmacy = new Doctor_Pharmacy()
                {
                    PharmacyId = newPharmacy.Id,
                    DoctorId = doctorId
                };
                await _context.DoctorsPharmacies.AddAsync(newDoctorPharmacy);
            }
            await _context.SaveChangesAsync();

            //Add Pharmacy DeliveryPersons
            foreach (var deliveryPersonId in data.DeliveryPersonIds)
            {
                var newDeliveryPersonPharmacy = new DeliveryPerson_Pharmacy()
                {
                    PharmacyId = newPharmacy.Id,
                    DeliveryPersonId = deliveryPersonId
                };
                await _context.DeliveryPersonsPharmacies.AddAsync(newDeliveryPersonPharmacy);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePharmacyAsync(NewPharmacyVM data)
        {
            var dbPharmacy = await _context.Pharmacies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPharmacy != null)
            {
                dbPharmacy.Logo = data.Logo;
                dbPharmacy.OwnerIdpicturefrontURL = data.OwnerIdpicturefrontURL;
                dbPharmacy.OwnerIdpicturebackURL = data.OwnerIdpicturebackURL;
                dbPharmacy.PharmacyRegistrationCertificatePicture = data.PharmacyRegistrationCertificatePicture;
                dbPharmacy.Description = data.Description;
                dbPharmacy.LocatedNearsetCity = data.LocatedNearestCity;
                dbPharmacy.OwnersLicenseIDPicture = data.OwnersLicenseIDPicture;
                dbPharmacy.PharmacyAddress = data.PharmacyAddress;
                dbPharmacy.PharmacyName = data.PharmacyName;
                dbPharmacy.WhatsAppNumber = data.WhatsAppNumber;
                dbPharmacy.PharmacyRegisteredNumber = data.PharmacyRegisteredNumber;
                dbPharmacy.OwnerFirstName = data.OwnerFirstName;
                dbPharmacy.OwnerLastName = data.OwnerLastName;
                dbPharmacy.OwnerFullName = data.OwnerFullName;
                dbPharmacy.OwnersNIC = data.OwnersNIC;
                dbPharmacy.RegistrationDate = data.RegistrationDate;
                dbPharmacy.GeoCoordinatesGoogleLocation = data.GeoCoordinatesGoogleLocation;
                dbPharmacy.ContactNumber = data.ContactNumber;
                dbPharmacy.EmergencyContactNumber = data.EmergencyContactNumber;

                await _context.SaveChangesAsync();
            }

            //Remove Existing Doctors
            var existingDoctorsesDb = _context.DoctorsPharmacies.Where(n => n.DoctorId == data.Id).ToList();
            _context.DoctorsPharmacies.RemoveRange(existingDoctorsesDb);
            await _context.SaveChangesAsync();

            //Add Pharmacy Doctors
            foreach (var doctorId in data.DoctorIds)
            {
                var newDoctorPharmacy = new Doctor_Pharmacy()
                {
                    PharmacyId = data.Id,
                    DoctorId = doctorId
                };
                await _context.DoctorsPharmacies.AddAsync(newDoctorPharmacy);
            }
            await _context.SaveChangesAsync();


        


            //Remove Existing Delivery Persons
            var existingDeliveryPersonsDb = _context.DeliveryPersonsPharmacies.Where(n => n.DeliveryPersonId == data.Id).ToList();
            _context.DeliveryPersonsPharmacies.RemoveRange(existingDeliveryPersonsDb);
            await _context.SaveChangesAsync();


            //Add Pharmacies Deli
            foreach (var delpersonId in data.DeliveryPersonIds)
            {
                var newDeliveryPerson = new DeliveryPerson_Pharmacy()
                {
                    PharmacyId = data.Id,
                    DeliveryPersonId = delpersonId
                };
                await _context.DeliveryPersonsPharmacies.AddAsync(newDeliveryPerson);
            }




            await _context.SaveChangesAsync();
        }
    }
}
