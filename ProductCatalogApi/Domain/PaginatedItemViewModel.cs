using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogApi.Domain
{
    public class PaginatedItemViewModel<T> where T:class 
    {
        public PaginatedItemViewModel(int pageIndex,int pageSize,IEnumerable<T> Data,int count)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.Count = Count;
            this.Data = Data;
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }

       




        


    }



   
}
