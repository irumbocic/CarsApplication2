using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.PageSortFilter
{
    public interface IPaging<T>
    {

        public int? page { get; set; }

        public Task<IPagedList<T>> PagingListAsync(IQueryable<T> pagedModel);
    }
}