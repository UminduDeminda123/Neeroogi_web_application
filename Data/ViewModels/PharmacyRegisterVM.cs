using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class PharmacyRegisterVM
    {


        [Display(Name = "Pharmacy Name")]
        [Required(ErrorMessage = "Pharmacy Name is required")]
        public string PharmacyName { get; set; }

        [Display(Name = "Owner's Name")]
        [Required(ErrorMessage = "Owner's Name is required")]
        public string PharmacyOwnerName { get; set; }



        [DataType(DataType.EmailAddress)]
        [Display(Name = "Pharmacy Email address")]
        [Required(ErrorMessage = "Pharmacy Email address is required")]
        public string PharamcyEmailAddress { get; set; }


        [Display(Name = "Confirm Pharmacy Email")]
        [Required(ErrorMessage = "Confirm Email is required")]
        [DataType(DataType.EmailAddress)]
        [Compare("PharamcyEmailAddress", ErrorMessage = "Email you entered do not match")]
        public string PharmacyConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string PharmacyPassword { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("PharmacyPassword", ErrorMessage = "Passwords do not match")]
        public string PharmacyConfirmPassword { get; set; }
    }
}
