using System;
using System.Collections.Generic;
using ProductCatalogApi.Domain;

namespace ProductCatalogApi.Interface
{
    public interface ICatalog
    {
        IList<CatalogType> GetCatalogTypes();

        IList<CatalogBrand> GetCatalogBrands();

        CatalogItem GetCatalogItem(int id);

        string SaveCatalogItem(CatalogItem catalogItem);

        string UpdateCatalogItem(CatalogItem catalogItem);

        string DeleteCatalogItem(int CatalogItemId);


        PaginatedItemViewModel<CatalogItem> catalogItems(int catalogTypeId,int catalogBrandId,int pageSize, int pageIndex);
    }
}
