using Neerogilksample.Data.Base;
using Neerogilksample.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class DigitalPrescription : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        public string CustomerUserEmail { get; set; }
        public string PharmacyUserEmail { get; set; }

        [Display(Name = "Link to the Signature")]
        [Required]
        //[Required(ErrorMessage = "Please enter the Last Name of the Doctor")]
        
        public string Signature { get; set; }

        [Display(Name = "Link to the Seal")]
        [Required]
        public string Seal { get; set; }

        [Display(Name = "Patient's Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Patient's Name must be in between 3 to 50 characters")]
        public string PatientName { get; set; }


        [Display(Name = "Patient's Address")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Patient's Address must be in between 3 to 50 characters")]
        public string PatientAddress { get; set; }

        public string CustomerName { get; set; }
        public DateTime BirthDay { get; set; }

        [Display(Name = "Patient's Age")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Description about Patient's Issue")]
        [Required]

        public string Description { get; set; }

        [Display(Name = "Date of Issue")]
        [Required]
        public DateTime Dateofissue { get; set; }

        [Display(Name = "Period of Meal")]
        [Required]
        public string Mealperiod { get; set; }

        [Display(Name = "Type of Drug")]
        [Required]
        public DrugProductCategory DrugProductCategory { get; set; }

        [Display(Name = "Patient's Contact Number")]
        [Required]
        public string ContactNumber { get; set; }
        [Display(Name = "Date of Expire")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        public string Lattiude { get; set; }
        public string Longtitude { get; set; }
        public string Location { get; set; }
        public string City { get; set; }

        //Medicine Row 1
        public string Medicine1 { get; set; }
        public string Dosage1 { get; set; }
        public string Medides1 { get; set; }
        //Medicine Row 2
        public string Medicine2 { get; set; }
        public string Dosage2 { get; set; }
        public string Medides2 { get; set; }
        //Medicine Row 3
        public string Medicine3 { get; set; }
        public string Dosage3 { get; set; }
        public string Medides3 { get; set; }
        //Medicine Row 4
        public string Medicine4 { get; set; }
        public string Dosage4 { get; set; }
        public string Medides4 { get; set; }
        //Medicine Row 5
        public string Medicine5 { get; set; }
        public string Dosage5 { get; set; }
        public string Medides5 { get; set; }
        //Medicine Row 6
        public string Medicine6 { get; set; }
        public string Dosage6 { get; set; }
        public string Medides6 { get; set; }

        //public int MyProperty { get; set; }

        //Relationships
        //Digital Prescription can have multiple General Mediciine Products
        public List<GeneralMedicineProducts> GeneralMedicinesProducts { get; set; }

        public List<DigitalPrescription_Pharmacy> DigitalPrescriptons_Pharmacies { get; set; }

        //Doctor
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public string Email { get; set; }

        public string UserDoctorId { get; set; }
        [ForeignKey(nameof(UserDoctorId))]
        public ApplicationUser UserDoctor { get; set; }

    }
}
