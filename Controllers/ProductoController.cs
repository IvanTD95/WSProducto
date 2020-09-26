using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSProducto.Datos.Contexto;
using WSProducto.Negocio;

namespace WSProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoManager produtoNegocio;

        public ProductoController()
        {
            this.produtoNegocio = new ProductoManager();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var lstProductos = this.produtoNegocio.GetProducto();
            return lstProductos;

        }

        // GET api/values
        [HttpGet("{SKU}")]
        public ActionResult<Producto> Get(string SKU)
        {
            var objProducto = this.produtoNegocio.GetProducto(SKU);
            return objProducto;

        }



        [HttpPost]
        public ActionResult<bool> Post([FromBody]Producto producto)
        {

            return produtoNegocio.postProducto(producto);
        }


        [HttpPut]
        public ActionResult<bool> Put([FromBody]Producto producto)
        {

            return produtoNegocio.putProducto(producto);
        }

        [HttpDelete("{SKU}")]
        public ActionResult<bool> Delete(string SKU)
        {

            return produtoNegocio.deleteProducto(SKU);
        }
    }
}
