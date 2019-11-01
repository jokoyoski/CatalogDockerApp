using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogApi.Domain;

namespace ProductCatalogApi.Data
{
    public class CatalogContext :DbContext
    {
        public CatalogContext(DbContextOptions options):base(options)
        {
            
        }


        public DbSet<CatalogBrand> CatalogBrand { get; set; }

        public DbSet<CatalogItem> CatalogItem { get; set; }

        public DbSet<CatalogType> CatalogType { get; set; }

        
    }
}
