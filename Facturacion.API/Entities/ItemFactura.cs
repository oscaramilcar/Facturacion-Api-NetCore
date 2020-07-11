using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Entities
{
    public class ItemFactura
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int FacturaId { get; set; }
        public EncabezadoFactura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
