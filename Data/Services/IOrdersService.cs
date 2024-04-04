using Neerogilksample.Data.Base;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public interface IOrdersService : IEntityBaseRepository<Orders>
    {
        Task<Orders> GetOrdersByIdAsync(int id);
        Task<OrdersDropdownsVM> GetOrdersDropdownsValues();
        Task AddNewOrderAsync(OrdersVM data, string userId, string userEmailAddress);
        Task UpdateOrderAsync(OrdersVM data, string userupdateId, string userupdateEmailAddress);
        Task<List<Orders>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
        //Task StoreDigitalPrescriptionAsync(string userId, string userEmailAddress);
    }
}
