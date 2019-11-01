using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogApi.Domain
{
    public static class PaginatedExtension
    {
       

        public static PaginatedItemViewModel<CatalogItem> CreateCreatePaginatedList(this IQueryable<CatalogItem> data, int pageNumber, int pageSize)
        {
            IEnumerable<CatalogItem> dataInfo = data.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int totalCount = data.Count();
            return new PaginatedItemViewModel<CatalogItem>(pageNumber, pageSize, dataInfo, totalCount);
        }
    }
}
