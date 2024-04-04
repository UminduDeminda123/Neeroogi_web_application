using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class NewDigitalPrescriptionDropdownsVM
    {

        public NewDigitalPrescriptionDropdownsVM()
        {
            Pharmacies = new List<Pharmacy>();
            Doctors = new List<Doctor>();
            Users = new List<ApplicationUser>();
         
        }
        public List<Pharmacy> Pharmacies { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List <ApplicationUser> Users { get; set; }

    }
}
