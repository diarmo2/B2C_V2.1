using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace B2C_V2_1.Helper
{

    public class ProductAPI
    {
        public HttpClient Initial()
        {
            var product = new HttpClient();
            product.BaseAddress = new Uri("http://kallsonysservices.cian.net.co/rest/productos/getproductos");
            return product;
        }
    }
}    