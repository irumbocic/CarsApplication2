using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Service.PageSortFilter
{
    public class Paging<T> : IPaging<T>
    {

        public int ? page { get; set; }
        public IPagedList<T> PagingList(List<T> sortedModel)
        {

            var pageNumber = this.page ?? 1;
            int pageSize = 10;

            var pagedModel = sortedModel.ToPagedList(pageNumber, pageSize);

            return pagedModel;
        }


    }
}
