using Service.Models;
using Service.PageSortFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Methods
{
    public interface IVehicleMakeService
    {
        public Task<VehicleMake> UpdateMakeAsync(VehicleMake updatedMake);
        public Task<VehicleMake> CreateMakeAsync(VehicleMake newMake);
        public Task<VehicleMake> DeleteMakeAsync(int id);
        public Task<VehicleMake> GetMakeAsync(int id);
        public Task<IPagedList<VehicleMake>> FindAsync(IFilterMake filter, ISortMake sort, IPaging<VehicleMake> paging);


    }
}
