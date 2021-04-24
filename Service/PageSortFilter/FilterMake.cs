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

        public int ? pageNumber { get; set; }

       

        public async Task<List<VehicleMake>> FilteringAsync(List<VehicleMake> vehicleMakes, string searchString, string currentFilter)
        {

            var newPagedList = vehicleMakes;

            if (searchString != null)
            {
                this.pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                newPagedList = await vehicleMakes.Where(m => m.Name.Contains(searchString) || m.Abrv.Contains(searchString)).ToListAsync(); // ovdje moram dodati i make-name, kad to sredim
            }

            SearchString = searchString;
            CurrentFilter = currentFilter;

            return newPagedList;
        }
    }
}
