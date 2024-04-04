using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data.Base;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public class DeliveryPersonsService : EntityBaseRepository<DeliveryPerson>, IDeliveryPersonsService
    {
        private readonly AppDbContext _context;
        public DeliveryPersonsService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<DeliveryPerson> GetDeliveryPersonByIdAsync(int id)
        {
            var deliveryPersonDetails = await _context.DeliveryPersons

                //.Include(dp => dp.Doctors_Pharmacies).ThenInclude(d => d.Doctor)
                //.Include(pd => pd.DeliveryPersons_Pharmacies).ThenInclude(p => p.DeliveryPerson)
                .FirstOrDefaultAsync(n => n.Id == id);

            return deliveryPersonDetails;
        }

        public async Task AddDeliveryPersonAsync(DeliveryPersonVM data)
        {
            var newDeliveryPerson = new DeliveryPerson()
            {
                ProfilePictureURL = data.ProfilePictureURL,
                IdpicturefrontURL = data.IdpicturefrontURL,
                IdpicturebackURL = data.IdpicturebackURL,
                LicenseFrontPictureURL = data.LicenseFrontPictureURL,
                LicenseBackPictureURL = data.LicenseBackPictureURL,
                PoliceReportsURL = data.PoliceReportsURL,
                appointedPharmacyEmail = data.appointedPharmacyEmail,
                FirstName = data.FirstName,
                LastName = data.LastName,
                FullName = data.FullName,
                Birthday = data.Birthday,
                NIC = data.NIC,
                ReceivedDateLicense = data.ReceivedDateLicense,
                WhatsAppNumber = data.WhatsAppNumber,
                ExpirationDate = data.ExpirationDate,
                ContactNumber = data.ContactNumber,
                EmergencyContactNumber = data.EmergencyContactNumber
            };
            await _context.DeliveryPersons.AddAsync(newDeliveryPerson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDeliveryPersonsAsync(DeliveryPersonVM deliveryPerson)
        {
            var dbDeliveryPerson = await _context.DeliveryPersons.FirstOrDefaultAsync(n => n.Id == deliveryPerson.Id);

            if (dbDeliveryPerson != null)
            {
                dbDeliveryPerson.ProfilePictureURL = dbDeliveryPerson.ProfilePictureURL;
                dbDeliveryPerson.IdpicturefrontURL = dbDeliveryPerson.IdpicturefrontURL;
                dbDeliveryPerson.IdpicturebackURL = dbDeliveryPerson.IdpicturebackURL;
                dbDeliveryPerson.LicenseFrontPictureURL = dbDeliveryPerson.LicenseFrontPictureURL;
                dbDeliveryPerson.LicenseBackPictureURL = dbDeliveryPerson.LicenseBackPictureURL;
                dbDeliveryPerson.PoliceReportsURL = dbDeliveryPerson.PoliceReportsURL;
                dbDeliveryPerson.appointedPharmacyEmail = dbDeliveryPerson.appointedPharmacyEmail;
                dbDeliveryPerson.FirstName = dbDeliveryPerson.FirstName;
                dbDeliveryPerson.LastName = dbDeliveryPerson.LastName;
                dbDeliveryPerson.FullName = dbDeliveryPerson.FullName;
                dbDeliveryPerson.Birthday = dbDeliveryPerson.Birthday;
                dbDeliveryPerson.NIC = dbDeliveryPerson.NIC;
                dbDeliveryPerson.ReceivedDateLicense = dbDeliveryPerson.ReceivedDateLicense;
                dbDeliveryPerson.WhatsAppNumber = dbDeliveryPerson.WhatsAppNumber;
                dbDeliveryPerson.ExpirationDate = dbDeliveryPerson.ExpirationDate;
                dbDeliveryPerson.ContactNumber = dbDeliveryPerson.ContactNumber;
                dbDeliveryPerson.EmergencyContactNumber = dbDeliveryPerson.EmergencyContactNumber;

                await _context.SaveChangesAsync();
            }


            await _context.SaveChangesAsync();
        }
    }
}