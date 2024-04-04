using Neerogilksample.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class Orders : IEntityBase
    {
        [Key]
        public int Id { get; set; }

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

        public string item1 { get; set; }
        public double price1 { get; set; }
        public string item2 { get; set; }
        public double price2 { get; set; }
        public string item3 { get; set; }
        public double price3 { get; set; }
        public string item4 { get; set; }
        public double price4 { get; set; }
        public string item5 { get; set; }
        public double price5 { get; set; }
        public string item6 { get; set; }
        public double price6 { get; set; }
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

        //DeliveryPerson Details

        [Display(Name = "Customer's Name")]
        public string customerNametoDeliver { get; set; }

        [Display(Name = "Contact Number to Deliver")]
        public string customerDeliveryContactNumber { get; set; }


        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }
        public string Email { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public ApplicationUser AppUser { get; set; }
    }
}

//Pharmacy to Customer and Delivery Person

//Pharmacy to Customer
//Generate Bill Option - Form ekak hadala 
//	Form
//	Tag Customer

//Pharmacy to Delivery Person
//Generate Order - Form eka


//Send Bill --> Customer
//Send Bill/Order --> Delivery Person

//Generate Bill / Send order to DP

//Customer Name

//To Include in Customer Edit Opportunity
//Landmark
//Delivery Address + Wathsala Google Maps

//Recepient Details

//Tag - Customer
//Customer First Name
//Customer lastName
//Contact Number
//LandMarks
//Product Details 

//Total

//Send Delivery Information

//Tag - Delivery Person
//Customer Name
//Customer Contact Number

//Total


//Oder/Payment Details

//PayOnline

//Paypal

//Pay On Delivery
//Master Card
//Visa Card