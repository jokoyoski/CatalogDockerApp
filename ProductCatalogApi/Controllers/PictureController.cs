using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCatalogApi.Interface;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : ControllerBase
    {

        private readonly IHostingEnvironment hostingEnviroment;

        private readonly IPicture picture;
        private readonly ICatalog catalog;

        private readonly ILogger<PictureController> _logger;

        public PictureController(ILogger<PictureController> logger, IPicture picture)
        {
            _logger = logger;
            this.picture = picture;

        }

        [HttpGet("GetPicture")]
        public IActionResult GetPicture(int id)
        {

            var pictureInfo = this.picture.GetPictureById(id);
            _logger.LogDebug("lol");
            return File(pictureInfo, "image/png");

        }

      
    }
}

