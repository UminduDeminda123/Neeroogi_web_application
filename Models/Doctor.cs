using Neerogilksample.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class Doctor : IEntityBase
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture Link")]
        //[Required(ErrorMessage = "Please enter the Link to the Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "ID Picture - Front Side")]
        //[Required(ErrorMessage = "Please enter the Link to the ID Picture")]
        public string IdpicturefrontURL { get; set; }
        [Display(Name = "ID Picture - Back Side")]
        //[Required(ErrorMessage = "Please enter the Link to the ID Picture")]
        public string IdpicturebackURL { get; set; }
        [Display(Name = "Official ID Picture - Front")]
        //[Required(ErrorMessage = "Please enter the Link to the Official ID Picture")]
        public string OfficialIDFrontPictureURL { get; set; }

        [Display(Name = "Official ID Picture - Back")]
        //[Required(ErrorMessage = "Please enter the Link to the Official ID Picture")]
        public string OfficialIDBackPictureURL { get; set; }

        [Display(Name = "Verified Certificates")]
        //[Required(ErrorMessage = "Please enter the Link to the Verified Certificate")]
        public string VerifiedCertificateURL { get; set; }

        [Display(Name = "Special Reports")]
        //[Required(ErrorMessage = "Please enter the Link to the Special Reports")]
        public string SpecialReportsURL { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter the First Name of the Doctor")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be in between 3 to 50 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter the Last Name of the Doctor")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be in between 3 to 50 characters")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter the Full Name of the Doctor")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be in between 3 to 50 characters")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please Enter the Contatc Number Correctly")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "Please specify an Emergency Contact Number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please neter the Emergency Contact Number correctly")]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        //[Required(ErrorMessage = "Please enter the Birthday correctly")]
        public DateTime Birthday { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter the correct Registration Number")]
        [Display(Name = "Government Registration Number")]
        //[Required(ErrorMessage = "Please enter Government Registration Number")]
        public string RegNumber { get; set; }

        [Display(Name = "National Identity Card Number")]
        //[Required(ErrorMessage = "Please enter the NIC Number correctly")]
        public int NIC { get; set; }
        [Display(Name = "Graduated University")]
        //[Required(ErrorMessage = "Enter the University Name Correctly")]
        public string GraduatedUniversity { get; set; }
        [Display(Name = "Graduated Year")]
        //[Required(ErrorMessage = "Please enter the Correct Graduated Year")]
        public int GraduatedYear { get; set; }
        [Display(Name = "Degree")]
        //[Required(ErrorMessage = "Please enter the Degree name correctly")]
        public string Degree { get; set; }
        [Display(Name = "Degree Specialization")]
        //[Required(ErrorMessage = "Please enter the Specialization of the Degree")]
        public string DegreeSpecialization { get; set; }

        
        //Relationships
        //Doctor can release multiple Digital Prescriptions

        public List<DigitalPrescription> DigitalPrescriptions { get; set; }
        //public List<DigitalPrescription> DigitalPrescriptionnew{get; set; }
        public List<Doctor_Pharmacy> Doctors_Pharmacies { get; set; }


    }
}
