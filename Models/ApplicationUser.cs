using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        // Customer
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }


        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        
        public string ConfirmPassword { get; set; }

        //Doctor

        [Display(Name = "Doctor First Name")]
        public string DoctorFirstName { get; set; }



        [Display(Name = "Doctor Last Name")]
        public string DoctorLastName { get; set; }


        [Display(Name = "Email address")]
        public string DoctorEmailAddress { get; set; }


        [Display(Name = "Confirm Email")]
        public string DoctorConfirmEmail { get; set; }

        [Display(Name = "Password")]
        public string DoctorPassword { get; set; }

        [Display(Name = "Confirm password")]

        public string DoctorConfirmPassword { get; set; }

        //Pharmacist

        [Display(Name = "Pharmacy Name")]
        public string PharmacyName { get; set; }



        [Display(Name = "Pharmacy's Owner Name")]
        public string PharmacyOwnerName { get; set; }


        [Display(Name = "Email address")]
        public string PharamcyEmailAddress { get; set; }


        [Display(Name = "Confirm Email")]
        public string PharmacyConfirmEmail { get; set; }

        [Display(Name = "Password")]
        public string PharmacyPassword { get; set; }

        [Display(Name = "Confirm password")]

        public string PharmacyConfirmPassword { get; set; }

        //DeliveryPerson

        [Display(Name = "Delivery Person First Name")]
        public string DeliveryPersonFirstName { get; set; }



        [Display(Name = "Delivery Person Last Name")]
        public string DeliveryPersonLastName { get; set; }


        [Display(Name = "Email address")]
        public string DPersonEmailAddress { get; set; }


        [Display(Name = "Confirm Email")]
        public string DPersonConfirmEmail { get; set; }

        [Display(Name = "Password")]
        public string DPersonPassword { get; set; }

        [Display(Name = "Confirm password")]

        public string DPersonConfirmPassword { get; set; }
    }
}
