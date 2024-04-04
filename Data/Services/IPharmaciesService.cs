using Neerogilksample.Data.Base;
using Neerogilksample.Data.ViewModels;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public interface IPharmaciesService : IEntityBaseRepository<Pharmacy>
    {
        Task<Pharmacy> GetPharmacyByIdAsync(int id);
        Task<NewPharmacyDropdownsVM> GetNewPharmacyDropdownsValues();
        Task AddNewPharmacyAsync(NewPharmacyVM data);
        Task UpdatePharmacyAsync(NewPharmacyVM data);

    }
}
