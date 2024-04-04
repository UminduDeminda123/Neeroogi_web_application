using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.ViewModels
{
    public class OrdersDropdownsVM
    {
        public OrdersDropdownsVM()
        {
            AppUsers = new List<ApplicationUser>();
        }
        public List<ApplicationUser> AppUsers { get; set; }
    }
}
