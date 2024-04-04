using Neerogilksample.Data.Base;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public interface IDeliveryPersonsService : IEntityBaseRepository<DeliveryPerson>
    {

        Task<DeliveryPerson> GetDeliveryPersonByIdAsync(int id);
        //Task<NewPharmacyDropdownsVM> GetNewPharmacyDropdownsValues();
        Task AddDeliveryPersonAsync(DeliveryPersonVM data);
        Task UpdateDeliveryPersonsAsync(DeliveryPersonVM deliveryPerson);
    }
}
