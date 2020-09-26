using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSProducto.Datos.Contexto;

namespace WSProducto.Datos
{
    public class ProductoDatos
    {
        public TRUPERContex context;

        public List<Producto> SelectProductos()
        {
            var lstProducto = new List<Producto>();

            using (var context = new TRUPERContex())
            {

                lstProducto = context.Producto.ToList();

            }
                return lstProducto;
        }


        public Producto SelectProductoId(string SKU)
        {
            var objProducto = new Producto();

            using (var context = new TRUPERContex())
            {
                objProducto = context.Producto.Find(SKU);

            }
            return objProducto;
        }


        public bool InsertProducto(Producto producto)
        {
            var insertado = false;

            using (var context = new TRUPERContex())
            {
                context.Producto.Add(producto);

                insertado = context.SaveChanges() > 0 ? true : false;
            }

            return insertado;
        }

        public bool UpdateProducto(Producto producto)
        {
            bool actualizado = false;

            var objProducto = new Producto();

            using (var context = new TRUPERContex())
            {
                objProducto = context.Producto.Where(x => x.Sku == producto.Sku).FirstOrDefault();

                if (objProducto != null)
                {
                
                        objProducto.NombreProducto = producto.NombreProducto;
                        objProducto.Precio = producto.Precio;
                   
                    actualizado = context.SaveChanges() > 0 ? true : false;
                }

            }

            return actualizado;
        }




        public bool DeleteProducto(string SKU)
        {
           
            bool eliminado = false;
            var objProducto = new Producto();

            using (var context = new TRUPERContex())
            {
                objProducto = context.Producto.Where(x => x.Sku == SKU).FirstOrDefault();
                if (objProducto != null)
                {
                    context.Producto.Remove(objProducto);

                    eliminado = context.SaveChanges() > 0 ? true : false;
                }

            }

            return eliminado;
        }






    }
}
