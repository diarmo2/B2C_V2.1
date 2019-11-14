using B2C_V2_1.Helper;
using B2C_V2_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace B2C_V2_1.Controllers
{
    public class ProductController : Controller
    {

        /// <summary>
        /// Instancia de la clase Helper que contiene el endpoint
        /// </summary>
        ProductAPI _api = new ProductAPI();


        public async Task<ActionResult> ListProduct()
        {
            List<Product> products = new List<Product>();
            HttpClient product = _api.Initial();
            HttpResponseMessage res = await product.GetAsync("http://kallsonysservices.cian.net.co/rest/productos/getproductos");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(results);
            }

            return View(products);

        }

        public async Task<ActionResult> Product()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://kallsonysservices.cian.net.co/rest/productos/b2c_searchproduct?Tipo=2&ProductoId=0&ProductoNombre=TELE&ProductoDescripcion&CategoriaId=0");
            var productList = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(productList);

        }



        public async Task<ActionResult> Details(int Id)
        {
            var prod = new Product();
            HttpClient product = _api.Initial();
            HttpResponseMessage res = await product.GetAsync("http://kallsonysservices.cian.net.co/rest/productos/getproductos/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                prod = JsonConvert.DeserializeObject<Product>(results);
            }
            return View(prod);
        }

       
        /// <summary>
        /// Método Get que filtra resultados por comodine
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns>Productos filtrados</returns>
        //[HttpPost]
        public async Task<ActionResult> FindProduct(string id1)
        {
            var httpClient = new HttpClient();
            var prueba = "http://kallsonysservices.cian.net.co/rest/productos/b2c_searchproduct?Tipo=5&ProductoNombre=" + id1;
            var json = await httpClient.GetStringAsync(prueba);
            var productFilter = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(productFilter);
        }

    

    }
}