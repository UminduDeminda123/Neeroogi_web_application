using Neerogilksample.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class DeliveryPerson : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "ID Picture - Front Side")]
        public string IdpicturefrontURL { get; set; }

        [Display(Name = "ID Picture - Back Side")]
        public string IdpicturebackURL { get; set; }

        [Display(Name = "License Picture - Front Side")]
        public string LicenseFrontPictureURL { get; set; }

        [Display(Name = "License Picture - Back Side")]
        public string LicenseBackPictureURL { get; set; }
        [Display(Name = "Special Reports")]
        public string PoliceReportsURL { get; set; }
        //Delivery Person WhatsApp Number
        public string WhatsAppNumber { get; set; }
        public string  appointedPharmacyEmail { get; set; }

        [Required(ErrorMessage = "Please enter the First Name of the Delivery Person")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be in between 3 to 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be in between 33 to 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the Full Name")]
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name should be in between 33 to 50 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter the Birthday Correctly")]


        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please Enter the Contatc Number Correctly")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Please specify an Emergency Contact Number")]
        [StringLength(15, MinimumLength = 12, ErrorMessage = "Please neter the Emergency Contact Number correctly")]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter your NIC Number")]
        //StringLength eka hairiyata balala danna one
        [StringLength(15, MinimumLength = 12, ErrorMessage = "Please enter your National Idnetity Card Number Correctly")]
        public string NIC { get; set; }

        [Required(ErrorMessage = "Please enter the Received Date of the Licence")]
        [Display(Name = "Received Date-Licence")]
        public DateTime ReceivedDateLicense { get; set; }
        [Required(ErrorMessage = "Please enter the Expiration Date of the Licensc")]
        [Display(Name = "Expiration Date of the License")]
        public DateTime ExpirationDate { get; set; }




        //Relationships
        public List<DeliveryPerson_Pharmacy> DeliveryPersons_Pharmacies { get; set; }
    }
}
