using Service.Methods;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Service.PageSortFilter
{
    public class FilterMake : IFilterMake
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public IQueryable<VehicleMake> Filtering(IQueryable<VehicleMake> vehicleMakes, IFilterMake filterMake)
        {

            var newPagedList = vehicleMakes;

            if (filterMake.SearchString == null)
            {
                filterMake.SearchString = filterMake.CurrentFilter;
            }

            if (!String.IsNullOrEmpty(filterMake.SearchString))
            {
                newPagedList = from makes in vehicleMakes
                               where (makes.Name.Contains(filterMake.SearchString) || makes.Abrv.Contains(filterMake.SearchString))
                               select makes;
            }

            return newPagedList;
        }
    }
}
