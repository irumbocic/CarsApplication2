using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface ISortMake
    {

        public string SortOrder { get; set; }
        public Task<List<VehicleMake>> OrderingAsync(List<VehicleMake> filterMake, string SortOrder);
    }
}
