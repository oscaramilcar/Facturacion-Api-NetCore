using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}
