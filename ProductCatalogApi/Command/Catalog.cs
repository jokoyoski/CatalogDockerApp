using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using ProductCatalogApi.Data;
using ProductCatalogApi.Domain;
using ProductCatalogApi.Interface;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalogApi.Command
{
    public class Catalog:ICatalog
    {
        private readonly IOptionsSnapshot<CatalogSettings> _settings;
        private readonly CatalogContext catalogContext
; public Catalog(CatalogContext catalogContext, IOptionsSnapshot<CatalogSettings> settings)
        {
           
            _settings = settings;
            this.catalogContext = catalogContext;
        }

        public PaginatedItemViewModel<CatalogItem> catalogItems(int catalogTypeId,int catalogBrandId,int pageSize, int pageIndex)
        {
            IQueryable<CatalogItem> items;

            if (catalogTypeId>0)
            {
                items = this.catalogContext.CatalogItem.Where(c=>c.CatalogTypeId==catalogTypeId);

            }
            else
            {
                items = this.catalogContext.CatalogItem.Where(c => c.CatalogBrandId == catalogBrandId);
            }

               

            return items.CreateCreatePaginatedList(pageIndex, pageSize);
        }

        public string DeleteCatalogItem(int catalogTypeId)
        {
            var result = string.Empty;

            try
            {
                var catalogInfo = this.catalogContext.CatalogItem.SingleOrDefault(x => x.id == catalogTypeId);

                if (catalogInfo != null)
                {
                    this.catalogContext.CatalogItem.Remove(catalogInfo);
                }
            }
            catch (DbUpdateException ex)
            {
                result = $"Your info cannot be deleted beacuse {ex}";
            }


            return result;
        }

        public IList<CatalogBrand> GetCatalogBrands()
        {
            return this.catalogContext.CatalogBrand.ToList();
        }

        public CatalogItem GetCatalogItem(int id)
        {
            var pictureFileInfo = this.catalogContext.CatalogItem.SingleOrDefault(x => x.id == id);
            if(pictureFileInfo!=null)
            {
                pictureFileInfo.PictureUrl = pictureFileInfo.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _settings.Value.ExternalCatalogBaseUrl);
            }
            return pictureFileInfo;
        }

        public IList<CatalogType> GetCatalogTypes()
        {
            return this.catalogContext.CatalogType.ToList();
        }

        public string SaveCatalogItem(CatalogItem catalogItem)
        {
            var result = string.Empty;

            try
            {
                this.catalogContext.CatalogItem.Add(catalogItem);
                this.catalogContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                result = $"Your info cannot be saved beacuse {ex}";
            }


            return result;

        }

        public string UpdateCatalogItem(CatalogItem catalogItem)
        {


           

            var result = string.Empty;

            try
            {
                var catalogInfo = this.catalogContext.CatalogItem.SingleOrDefault(x => x.id == catalogItem.id);

                if (catalogInfo != null)
                {
                    catalogInfo.CatalogBrandId = catalogItem.CatalogBrandId;
                    catalogInfo.CatalogTypeId = catalogItem.CatalogTypeId;
                    catalogInfo.Description = catalogItem.Description;
                    catalogInfo.Name = catalogItem.Name;
                    catalogInfo.PictureFileName = catalogItem.PictureFileName;
                    catalogInfo.PictureUrl = catalogItem.PictureUrl;
                    catalogInfo.Price = catalogItem.Price;
                }
            }
            catch (DbUpdateException ex)
            {
                result = $"Your info cannot be updated beacuse {ex}";
            }


            return result;
        }
    }
}
