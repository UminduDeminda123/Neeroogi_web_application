using Neerogilksample.Data.Base;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public interface IDigitalPrescriptionsService : IEntityBaseRepository<DigitalPrescription>
    {
        Task<DigitalPrescription> GetDigitalPrescriptionByIdAsync(int id);
        Task<NewDigitalPrescriptionDropdownsVM> GetNewDigitalPrescriptionDropdownsValues();
        Task AddNewDigitalPrescriptionAsync(NewDigitalPrescriptionVM data, string userId, string userEmailAddress);
        Task UpdateDigitalPrescriptionAsync(NewDigitalPrescriptionVM data, string userupdateId, string userupdateEmailAddress);
        Task<List<DigitalPrescription>> GetDigitalPrescriptionByUserIdAndRoleAsync(string userId, string userRole);
        //Task StoreDigitalPrescriptionAsync(string userId, string userEmailAddress);
    }
}
