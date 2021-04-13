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

        public int ? pageNumber { get; set; }

       

        public async Task<List<VehicleModel>> Filtering(List<VehicleModel> vehicleModels, string searchString, string currentFilter)
        {

            var newPagedList = vehicleModels;

            if (searchString != null)
            {
                this.pageNumber = 1;
                currentFilter = searchString;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                newPagedList = vehicleModels.Where(m => m.Name.Contains(searchString) || m.Abrv.Contains(searchString) || m.VehicleMake.Name.Contains(searchString)).ToList(); // ovdje moram dodati i make-name, kad to sredim
            }
            ;
            return newPagedList;
        }
    }
}
