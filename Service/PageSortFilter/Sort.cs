using Service.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Models;

namespace Service.PageSortFilter
{
    public class Sort : ISort
    {

        public string SortOrder { get; set; }


        public async Task<List<VehicleModel>> Ordering(List<VehicleModel> filterModel, string SortOrder)
        {
            //IEnumerable<VehicleModel> vehicleModels = await vehicleModelService.FindAsync();

            switch (SortOrder)
            {
                case "nameDesc":
                    filterModel = filterModel.OrderByDescending(m => m.Name).ToList();
                    break;
                case "abrvDesc":
                    filterModel = filterModel.OrderByDescending(m => m.Abrv).ToList();
                    break;
                case "makeIdDesc":
                    filterModel = filterModel.OrderByDescending(m => m.MakeId).ToList();
                    break;
                default:
                    filterModel = filterModel.OrderBy(m => m.Id).ToList();
                    break;
            }
            return filterModel;
        }



    }
}
