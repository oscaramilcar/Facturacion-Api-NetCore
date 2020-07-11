using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Entities
{
    public class EncabezadoFactura
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<ItemFactura> ItemFacturas { get; set; } = new List<ItemFactura>();
    }
}
