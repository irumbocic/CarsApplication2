using System.Collections.Generic;
using X.PagedList;

namespace Service.PageSortFilter
{
    public interface IPaging<T>
    {

        public int ? page { get; set; }

        public IPagedList<T> PagingList(List<T> pagedModel);
    }
}