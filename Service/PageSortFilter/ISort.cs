using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface ISort
    {

        public string SortOrder { get; set; }
        public Task<List<VehicleModel>> Ordering(List<VehicleModel> filterModel, string SortOrder);
    }
}
