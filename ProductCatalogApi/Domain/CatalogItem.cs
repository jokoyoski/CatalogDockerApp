using System;
namespace ProductCatalogApi.Domain
{
    public class CatalogItem
    {
        public CatalogItem()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>


        public decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string PictureFileName { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string PictureUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public CatalogType catalogType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CatalogBrand catalogBrand { get; set; }


        public int CatalogBrandId { get; set; }

        public int CatalogTypeId { get; set; }
    }
}
