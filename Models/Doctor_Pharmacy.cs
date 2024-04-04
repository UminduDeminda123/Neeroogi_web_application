using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class Doctor_Pharmacy
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
