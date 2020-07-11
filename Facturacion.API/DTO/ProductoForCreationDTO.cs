using System;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.API.DTO
{
    public class ProductoForCreationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}