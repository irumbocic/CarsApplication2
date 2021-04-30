using X.PagedList;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Service.PageSortFilter
{
    public interface IFilterMake
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }

        public IQueryable<VehicleMake> Filtering(IQueryable<VehicleMake> vehicleMakes, IFilterMake filterMake);

    }
}
