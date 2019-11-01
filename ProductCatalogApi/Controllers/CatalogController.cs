using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCatalogApi.Domain;
using ProductCatalogApi.Interface;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {

        private readonly IHostingEnvironment hostingEnviroment;

        private readonly IPicture picture;
        private readonly ICatalog catalog;

        private readonly ILogger<PictureController> _logger;

        public CatalogController(ILogger<PictureController> logger, IPicture picture,ICatalog catalog)
        {
            _logger = logger;
            this.picture = picture;
            this.catalog = catalog;

        }

       

        [HttpGet("CatalogTypes")]
        public IActionResult CatalogTypes()
        {

            var pictureInfo = this.catalog.GetCatalogTypes();
            if (pictureInfo == null)
            {
                return NotFound();
            }
            return Ok(pictureInfo);

        }

        [HttpGet("CatalogBrands")]
        public IActionResult CatalogBrands()
        {

            var pictureInfo = this.catalog.GetCatalogBrands();
            if (pictureInfo == null)
            {
                return NotFound();
            }
            return Ok(pictureInfo);

        }

        [HttpGet("CatalogItem")]
        public IActionResult CatalogItem(int id)
        {

            var pictureInfo = this.catalog.GetCatalogItem(id);
            if (pictureInfo == null)
            {
                return NotFound();
            }
            return Ok(pictureInfo);

        }

        [HttpGet("CatalogItems")]
        public IActionResult CatalogItems(int catalogTypeId = 0, int catalogBrandId = 0, int pageSize = 4, int pageIndex = 0)
        {

            var catalogItemInfo = this.catalog.catalogItems(catalogTypeId, catalogBrandId, pageSize, pageIndex);

            return Ok(catalogItemInfo);
        }

        [HttpDelete("DeleteCatalogItem")]
        public IActionResult DeleteCatalogItem(int catalogItemId)
        {

            var catalogItemInfo = this.catalog.DeleteCatalogItem(catalogItemId);

            if(!string.IsNullOrEmpty(catalogItemInfo))
            {
                return StatusCode(400, catalogItemInfo);
            }


            return Ok("Deleted Sucessfully");
               }



        [HttpPost("CreateCatalogItem")]
        public IActionResult CreateCatalogItem(CatalogItem catalogItem)
        {

            var catalogItemInfo = this.catalog.SaveCatalogItem(catalogItem);

            if (!string.IsNullOrEmpty(catalogItemInfo))
            {
                return StatusCode(400, catalogItemInfo);
            }

            return Ok("Saved Sucessfully");


        }


        [HttpPost("UpdateCatalogItem")]
        public IActionResult UpdateCatalogItem(CatalogItem catalogItem)
        {

            var catalogItemInfo = this.catalog.UpdateCatalogItem(catalogItem);

            if (!string.IsNullOrEmpty(catalogItemInfo))
            {
                return StatusCode(400, catalogItemInfo);
            }

            return CreatedAtAction(nameof(CatalogItem), new { id = catalogItem.id });





        }



    }
}

