using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Models;
using Service.PageSortFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Methods
{
    public interface IVehicleModelService
    {
        public Task<VehicleModel> UpdateModelAsync(VehicleModel updatedModel);
        public Task<VehicleModel> CreateModelAsync(VehicleModel newModel);
        public Task<VehicleModel> DeleteModelAsync(int id);
        public Task<VehicleModel> GetModelAsync(int id);
        public Task<IPagedList<VehicleModel>> FindAsync(IFilter filter, ISort sort, IPaging<VehicleModel> paging);

        public Task<IEnumerable<SelectListItem>> GetListOfMakeNamesAsync();


    }
}
