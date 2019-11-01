using System;
using System.Collections.Generic;
using ProductCatalogApi.Domain;

namespace ProductCatalogApi.Interface
{
    public  interface IPicture
    {
       byte[] GetPictureById(int id);
       

    }
}
