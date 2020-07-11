using System;

namespace Facturacion.API.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}