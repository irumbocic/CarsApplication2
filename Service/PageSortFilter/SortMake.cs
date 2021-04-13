using Service.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Models;
using X.PagedList;

namespace Service.PageSortFilter
{
    public class SortMake : ISortMake
    {

        public string SortOrder { get; set; }


        public async Task<List<VehicleMake>> OrderingAsync(List<VehicleMake> filterMake, string SortOrder)
        {

            switch (SortOrder)
            {
                case "nameDesc":
                    filterMake = await filterMake.OrderByDescending(m => m.Name).ToListAsync();
                    break;
                case "abrvDesc":
                    filterMake = await filterMake.OrderByDescending(m => m.Abrv).ToListAsync();
                    break;
                default:
                    filterMake = await filterMake.OrderBy(m => m.Id).ToListAsync();
                    break;
            }
            return filterMake;
        }



    }
}
