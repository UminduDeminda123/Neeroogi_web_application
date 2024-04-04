using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class DoctorRegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Display(Name = "Doctor First name")]
        [Required(ErrorMessage = "First name is required")]
        public string DoctorFirstName { get; set; }

        [Display(Name = "Doctor Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string DoctorLastName { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Doctor Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string DoctorEmailAddress { get; set; }


        [Display(Name = "Confirm Doctor Email")]
        [Required(ErrorMessage = "Confirm Email is required")]
        [DataType(DataType.EmailAddress)]
        [Compare("DoctorEmailAddress", ErrorMessage = "Email you entered do not match")]
        public string DoctorConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string DoctorPassword { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("DoctorPassword", ErrorMessage = "Passwords do not match")]
        public string DoctorConfirmPassword { get; set; }
    }
}
