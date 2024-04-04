using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class DeliveryPerson_Pharmacy
    {
        public int DeliveryPersonId { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
