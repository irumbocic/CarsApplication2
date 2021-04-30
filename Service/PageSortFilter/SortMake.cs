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


        public IQueryable<VehicleMake> Ordering(IQueryable<VehicleMake> filterMake, ISortMake sortMake)
        {

            switch (sortMake.SortOrder)
            {
                case "nameDesc":
                    filterMake = filterMake.OrderByDescending(m => m.Name);
                    break;
                case "abrvDesc":
                    filterMake = filterMake.OrderByDescending(m => m.Abrv);
                    break;
                default:
                    filterMake = filterMake.OrderBy(m => m.Id);
                    break;
            }
            return filterMake;
        }



    }
}
