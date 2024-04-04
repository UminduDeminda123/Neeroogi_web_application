using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class DigitalPrescription_Pharmacy
    {
        public int DigitalPrescriptionId { get; set; }
        public DigitalPrescription DigitalPrescription { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
