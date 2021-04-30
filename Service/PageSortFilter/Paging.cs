using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.PageSortFilter
{
    public class Paging<T> : IPaging<T>
    {

        public int ? page { get; set; }

        public async Task<IPagedList<T>> PagingListAsync(IQueryable<T> sortedModel)
        {
            var pageNumber = page ?? 1;
            int pageSize = 10;

            var pagedModel = await sortedModel.ToPagedListAsync(pageNumber, pageSize);

            return pagedModel;
        }


    }
}
