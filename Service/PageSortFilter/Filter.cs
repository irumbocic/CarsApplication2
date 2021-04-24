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
    public class Filter : IFilter
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public int ? PageNumber { get; set; }

       

        public async Task<List<VehicleModel>> FilteringAsync(List<VehicleModel> vehicleModels, string searchString, string currentFilter)
        {
            
            var newPagedList = vehicleModels;

            if (searchString != null)
            {
                this.PageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                newPagedList = await vehicleModels.Where(m => m.Name.Contains(searchString) || m.Abrv.Contains(searchString) || m.VehicleMake.Name.Contains(searchString)).ToListAsync(); // ovdje moram dodati i make-name, kad to sredim
            }

            SearchString = searchString;
            CurrentFilter = currentFilter;
            ;
            return newPagedList;
        }
    }
}
