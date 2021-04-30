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



        public IQueryable<VehicleModel> Ordering(IQueryable<VehicleModel> filterModel, ISort sort)
        {
           

            switch (sort.SortOrder)
            {
                case "nameDesc":
                    filterModel = filterModel.OrderByDescending(m => m.Name);
                    break;
                case "abrvDesc":
                    filterModel = filterModel.OrderByDescending(m => m.Abrv);
                    break;
                case "makeIdDesc":
                    filterModel = filterModel.OrderByDescending(m => m.MakeId);
                    break;
                default:
                    filterModel = filterModel.OrderBy(m => m.Id);
                    break;
            }

            return filterModel;
        }

    }
}
