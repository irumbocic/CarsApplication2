using X.PagedList;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface IFilterMake
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public int? pageNumber { get; set; }
        public Task<List<VehicleMake>> FilteringAsync(List<VehicleMake> vehicleMakes, string searchString, string currentFilter);
    }
}
