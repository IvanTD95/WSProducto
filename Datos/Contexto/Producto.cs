using System;
using System.Collections.Generic;

namespace WSProducto.Datos.Contexto
{
    public partial class Producto
    {
        public string Sku { get; set; }
        public decimal? Precio { get; set; }
        public string NombreProducto { get; set; }
    }
}
