using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class DeliveryPersonRegisterVM
    {

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        public string DeliveryPersonFirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string DeliveryPersonLastName { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string DPersonEmailAddress { get; set; }


        [Display(Name = "Confirm Email")]
        [Required(ErrorMessage = "Confirm Email is required")]
        [DataType(DataType.EmailAddress)]
        [Compare("DPersonEmailAddress", ErrorMessage = "Email you entered do not match")]
        public string DPersonConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string DPersonPassword { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("DPersonPassword", ErrorMessage = "Passwords do not match")]
        public string DPersonConfirmPassword { get; set; }
    }
}
