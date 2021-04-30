using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface ISortMake
    {

        public string SortOrder { get; set; }
        public IQueryable<VehicleMake> Ordering(IQueryable<VehicleMake> filterMake, ISortMake sortMake);
    }
}
