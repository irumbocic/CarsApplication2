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

        public int Count { get; set; }


        public IQueryable<VehicleModel> Ordering(IQueryable<VehicleModel> filterModel, Sort sort)
        {
           

            IQueryable<VehicleModel> test = filterModel;  // TEST
            switch (sort.SortOrder)
            {
                case "nameDesc":
                    test = test.OrderByDescending(m => m.Name);
                    break;
                case "abrvDesc":
                    test = test.OrderByDescending(m => m.Abrv);
                    break;
                case "makeIdDesc":
                    test = test.OrderByDescending(m => m.MakeId);
                    break;
                default:
                    test = test.OrderBy(m => m.Id);
                    break;
            }

            Count = test.Count();
            return test;
        }



    }
}
