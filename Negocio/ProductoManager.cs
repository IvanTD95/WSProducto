using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSProducto.Datos;
using WSProducto.Datos.Contexto;

namespace WSProducto.Negocio
{
    public class ProductoManager
    {


        private ProductoDatos productoDatos;
        public ProductoManager()
        {
            this.productoDatos = new ProductoDatos();
        }

        public List<Producto> GetProducto()
        {
            var lstProductos = new List<Producto>();

            lstProductos = productoDatos.SelectProductos();

            return lstProductos;
        }


        public Producto GetProducto(string SKU)
        {
            var objProductos = new Producto();

            objProductos = productoDatos.SelectProductoId( SKU);
            return objProductos;
        }

        
        public bool postProducto(Producto pedido)
        {
            return productoDatos.InsertProducto(pedido);
        }

        public bool putProducto(Producto pedido)
        {
            return productoDatos.UpdateProducto(pedido);
        }

        public bool deleteProducto(string SKU)
        {
            return productoDatos.DeleteProducto(SKU);
        }
    }
}
