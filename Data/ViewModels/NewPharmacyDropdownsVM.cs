using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class NewPharmacyDropdownsVM
    {
        public NewPharmacyDropdownsVM()
        {
            Doctors = new List<Doctor>();
            DeliveryPersons = new List<DeliveryPerson>();
       
        }
        public List<Doctor> Doctors { get; set; }
        public List<DeliveryPerson> DeliveryPersons { get; set; }
    
    }
}
