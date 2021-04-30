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

        public IQueryable<VehicleModel> Filtering(IQueryable<VehicleModel> vehicleModels, Filter filter)
        {

            var newPagedList = vehicleModels;


            if (filter.SearchString == null)
            {
                filter.SearchString = filter.CurrentFilter; 
            }
           

            if (!String.IsNullOrEmpty(filter.SearchString))
            {
                newPagedList = from models in vehicleModels
                               where(models.Name.Contains(filter.SearchString) || models.Abrv.Contains(filter.SearchString) || models.VehicleMake.Name.Contains(filter.SearchString))
                               select models; 
            }

            return newPagedList;
        }
    }
}
