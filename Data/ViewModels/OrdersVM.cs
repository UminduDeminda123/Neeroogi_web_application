using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class OrdersVM
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Email")]
        public string CustomerUserEmailTag { get; set; }
        public string DeliveryPersonUserEmailTag { get; set; }
        [Display(Name = "Date of Issue")]
        public DateTime DateofIssue { get; set; }
        //Customer Details
        [Display(Name = "Customer First Name")]
        public string customerFirstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string customerLastName { get; set; }

        [Display(Name = "Landmark")]
        public string Landmark { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        //Order details
        [Display(Name = "Enter Item 01")]
        public string item1 { get; set; }
        [Display(Name = "Enter Price")]
        public double price1 { get; set; }


        [Display(Name = "Enter Item 02")]
        public string item2 { get; set; }
        [Display(Name = "Enter Price")]
        public double price2 { get; set; }


        [Display(Name = "Enter Item 03")]
        public string item3 { get; set; }
        [Display(Name = "Enter Price")]
        public double price3 { get; set; }


        [Display(Name = "Enter Item 04")]
        public string item4 { get; set; }
        [Display(Name = "Enter Price")]
        public double price4 { get; set; }


        [Display(Name = "Enter Item 05")]
        public string item5 { get; set; }
        [Display(Name = "Enter Price")]
        public double price5 { get; set; }

        [Display(Name = "Enter Item 06")]
        public string item6 { get; set; }
        [Display(Name = "Enter Price")]
        public double price6 { get; set; }
        //DeliveryPerson Details

        [Display(Name = "Customer's Name")]
        public string customerNametoDeliver { get; set; }

        [Display(Name = "Contact Number to Deliver")]
        public string customerDeliveryContactNumber { get; set; }
        public int numberofUnits1 { get; set; }
        public int numberofUnits2 { get; set; }
        public int numberofUnits3 { get; set; }
        public int numberofUnits4 { get; set; }
        public int numberofUnits5 { get; set; }
        public int numberofUnits6 { get; set; }

        public double unitPrice1 { get; set; }
        public double unitPrice2 { get; set; }
        public double unitPrice3 { get; set; }
        public double unitPrice4 { get; set; }
        public double unitPrice5 { get; set; }
        public double unitPrice6 { get; set; }
        public double Total { get; set; }
        public double GrandTotal { get; set; }



        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        [Display(Name = "Customer ID")]
        public string CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public ApplicationUser CustomerUser { get; set; }
        [Display(Name ="Delivery Person ID")]
        public string DeliveryPersonAppUserId { get; set; }
        [ForeignKey(nameof(DeliveryPersonAppUserId))]
        public ApplicationUser DeliveryPersonAppUser { get; set; }
    }
}
