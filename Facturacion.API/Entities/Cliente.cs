using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(50)]
        public string Correo { get; set; }
        public ICollection<EncabezadoFactura> Facturas { get; set; } = new List<EncabezadoFactura>();
    }
}
