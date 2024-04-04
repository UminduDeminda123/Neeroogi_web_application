using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class PharmacyLoginVM
    {
        [Display(Name = "Pharmacy Email address")]
        [Required(ErrorMessage = "Pharmacy Email address is required")]
        public string PharamcyEmailAddress { get; set; }

        [Display(Name = "Pharmacy Password")]
        [Required]
        [DataType(DataType.Password)]
        public string PharmacyPassword { get; set; }
    }
}
