using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DeliveryPerson and Pharmacy
            modelBuilder.Entity<DeliveryPerson_Pharmacy>().HasKey(am => new
            {
                am.DeliveryPersonId,
                am.PharmacyId
            });

            modelBuilder.Entity<DeliveryPerson_Pharmacy>().HasOne(m => m.DeliveryPerson).WithMany(am => am.DeliveryPersons_Pharmacies).HasForeignKey(m => m.DeliveryPersonId);
            modelBuilder.Entity<DeliveryPerson_Pharmacy>().HasOne(m => m.Pharmacy).WithMany(am => am.DeliveryPersons_Pharmacies).HasForeignKey(m => m.PharmacyId);

            //Digital Prescription and Pharmacy Relationship
            modelBuilder.Entity<DigitalPrescription_Pharmacy>().HasKey(bm => new
            {
                bm.DigitalPrescriptionId,
                bm.PharmacyId
            });

            modelBuilder.Entity<DigitalPrescription_Pharmacy>().HasOne(m => m.DigitalPrescription).WithMany(am => am.DigitalPrescriptons_Pharmacies).HasForeignKey(m => m.DigitalPrescriptionId);
            modelBuilder.Entity<DigitalPrescription_Pharmacy>().HasOne(m => m.Pharmacy).WithMany(am => am.DigitalPrescriptons_Pharmacies).HasForeignKey(m => m.PharmacyId);

            //Doctor and Pharmacy
            modelBuilder.Entity<Doctor_Pharmacy>().HasKey(cm => new
            {
                cm.DoctorId,
                cm.PharmacyId
            });

            modelBuilder.Entity<Doctor_Pharmacy>().HasOne(m => m.Doctor).WithMany(am => am.Doctors_Pharmacies).HasForeignKey(m => m.DoctorId);
            modelBuilder.Entity<Doctor_Pharmacy>().HasOne(m => m.Pharmacy).WithMany(am => am.Doctors_Pharmacies).HasForeignKey(m => m.PharmacyId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Doctor_Pharmacy> DoctorsPharmacies { get; set; }
        public DbSet<DigitalPrescription> DigitalPrescriptions { get; set; }
        public DbSet<DigitalPrescription_Pharmacy> DigitalPrescriptionsPharmacies { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
        public DbSet<DeliveryPerson_Pharmacy> DeliveryPersonsPharmacies { get; set; }
        public DbSet<GeneralMedicineProducts> GeneralMedicineProducts { get; set; }
        public DbSet<GeneralMedicines> GeneralMedicines { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
