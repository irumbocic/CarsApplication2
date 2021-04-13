using X.PagedList;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface IFilter
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public int? pageNumber { get; set; }
        public Task<List<VehicleModel>> Filtering(List<VehicleModel> vehicleModels, string searchString, string currentFilter);
    }
}
