using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using ProductCatalogApi.Data;
using ProductCatalogApi.Domain;
using ProductCatalogApi.Interface;


namespace ProductCatalogApi.Command
{
    public class Picture:IPicture
    {
        private readonly IHostingEnvironment _hostingEnviroment;
       
        private readonly CatalogContext catalogContext
;        public Picture( IHostingEnvironment hostingEnvironment,CatalogContext catalogContext)
        {
            _hostingEnviroment = hostingEnvironment;
          
            this.catalogContext = catalogContext;
        }

       

        public byte[] GetPictureById(int id)
        {
            var wwwRoot = _hostingEnviroment.WebRootPath;
            if(string.IsNullOrWhiteSpace(wwwRoot))
            {
                _hostingEnviroment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                wwwRoot = _hostingEnviroment.WebRootPath;
            }

            var path = Path.Combine(wwwRoot + "/Pics/", "shoes-" + id + ".png");
            var buffer = System.IO.File.ReadAllBytes(path);

            return buffer;
        }
    }
}
