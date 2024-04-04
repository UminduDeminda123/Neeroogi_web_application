using Neerogilksample.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class Pharmacy : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Pharmacy - Logo")]
       
        public string Logo { get; set; }

        [Display(Name = "ID Picture - Front Side")]
        [Required]
        public string OwnerIdpicturefrontURL { get; set; }

        [Display(Name = "ID Picture - Back Side")]
        [Required]
        public string OwnerIdpicturebackURL { get; set; }

        [Display(Name = "Registration Certificate Picture ")]
        [Required]
        public string PharmacyRegistrationCertificatePicture { get; set; }
        [Display(Name = "Description of the Pharmacy ")]
        [Required]
        public string Description { get; set; }


        [Display(Name = "Owner's License Picture ")]
        [Required]
        public string OwnersLicenseIDPicture { get; set; }
        [Display(Name = "Pharmacy Address ")]
        [Required]
        public string  PharmacyAddress { get; set; }




        [Required(ErrorMessage = "Please enter the Pharmacy Name")]
        [Display(Name = "Pharmacy Name")]
        public string PharmacyName { get; set; }

        //[Required(ErrorMessage = "Please enter the Registration Number")]
        [Display(Name = "Pharmacy Registration Number")]
        //[StringLength(50, MinimumLength = 12, ErrorMessage = "Please enter the Pharmacy Registraion Number Correctly")]
        public int PharmacyRegistrationNumber { get; set; }
        [Required(ErrorMessage = "Please enter the FirstName of the Owner")]
        [Display(Name = "First Name of the Owner")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Owner's First Name should be in between 3 to 50 characters")]
        public string OwnerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Last Name of the Owner")]
        [Display(Name = "Last Name of the Owner")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Owner's Last Name should be in between 3 to 50 characters")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "Please enter the Full Name of the Owner")]
        [Display(Name = "Full Name of the Owner")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Owner's Full Name should be in between 3 to 50 characters")]
        public string OwnerFullName { get; set; }

        [Required(ErrorMessage = "Please enter the NIC of the Owner")]
        [Display(Name = "NIC of the Owner")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Owner's NIC should be in between 3 to 50 characters")]
        public string OwnersNIC { get; set; }

        [Required(ErrorMessage = "Please enter the Pharmacy Registration Number")]
        [Display(Name = "Registration Number of the Pharmacy")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Registration Number should be in between 3 to 50 characters")]
        public string PharmacyRegisteredNumber { get; set; }
        [Required(ErrorMessage = "Please correctly enter the Registration Date of the Pharmacy")]
        [Display(Name = "Date of Registration")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "Please enter the registration number correctly")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter the District that the Pharmacy is located")]
        [Display(Name = "District")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Please enter the District correctly")]
        //public string District { get; set; }

        //[Required(ErrorMessage = "Please enter the city that the Pharmacy is located")]
        //[Display(Name = "City")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "Please enter the City correctly")]
        ////public string City { get; set; }

        //[Required(ErrorMessage = "Please enter the Geo Coordinates that the Pharmacy is located")]
        //[Display(Name = "Google Location")]
        //[StringLength(50, MinimumLength = 10, ErrorMessage = "Please enter the Geo Coordinates correctly")]
        public string GeoCoordinatesGoogleLocation { get; set; }
        public string LocatedNearsetCity { get; set; }

        public string WhatsAppNumber { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please Enter the Contatc Number Correctly")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Please specify an Emergency Contact Number")]
        [StringLength(15, MinimumLength = 12, ErrorMessage = "Please neter the Emergency Contact Number correctly")]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        //public ProvinceName ProvinceName { get; set; }
        //public DistrictName DistrictName { get; set; }
        //public CityName CityName { get; set; }

        //Relationships

        // public List<DigitalPrescription> DigitalPrescriptions { get; set; }
        //public List<DeliveryPerson_Pharmacy> DeliveryPersons_Pharmacys { get; set; }

        //1 to many doctors/pharmacies

        public List<Doctor_Pharmacy> Doctors_Pharmacies { get; set; }

        public List<DeliveryPerson_Pharmacy> DeliveryPersons_Pharmacies { get; set; }

        public List<DigitalPrescription_Pharmacy> DigitalPrescriptons_Pharmacies { get; set; }
   
    }
}
