using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PageSortFilter
{
    public interface ISort
    {

        public string SortOrder { get; set; }
        public IQueryable<VehicleModel> Ordering(IQueryable<VehicleModel> filterModel, ISort sort);
    }
}
