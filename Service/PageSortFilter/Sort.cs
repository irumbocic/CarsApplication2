using Service.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Models;
using X.PagedList;

namespace Service.PageSortFilter
{
    public class Sort : ISort
    {

        public string SortOrder { get; set; }


        public async Task<List<VehicleModel>> OrderingAsync(List<VehicleModel> filterModel, string SortOrder)
        {
            //IEnumerable<VehicleModel> vehicleModels = await vehicleModelService.FindAsync();

            switch (SortOrder)
            {
                case "nameDesc":
                    filterModel = await filterModel.OrderByDescending(m => m.Name).ToListAsync();
                    break;
                case "abrvDesc":
                    filterModel = await filterModel.OrderByDescending(m => m.Abrv).ToListAsync();
                    break;
                case "makeIdDesc":
                    filterModel = await filterModel.OrderByDescending(m => m.MakeId).ToListAsync();
                    break;
                default:
                    filterModel = await filterModel.OrderBy(m => m.Id).ToListAsync();
                    break;
            }
            return filterModel;
        }



    }
}
