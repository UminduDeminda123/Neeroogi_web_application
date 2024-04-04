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
    public class GeneralMedicineProducts : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        public string ProductPictureURL { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Medicine")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter the medicine name correctly")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Manufactured Date")]
        public DateTime ManufacturedDate { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Name of the Manufactured Company")]
        public string ManufacturedCompanyName { get; set; }

        //Relationships
        public DrugProductCategory DrugProductCategory { get; set; }

        //DigitalPrescription
        public int DigitalPrescriptionId { get; set; }
        [ForeignKey("DigitalPrescriptionId")]
        public DigitalPrescription DigitalPrescription { get; set; }



    }
}
