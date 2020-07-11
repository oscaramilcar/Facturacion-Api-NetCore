using System.Collections.Generic;
using Facturacion.API.Entities;

namespace Facturacion.API.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public ICollection<EncabezadoFacturaDTO> Facturas { get; set; } = new List<EncabezadoFacturaDTO>();
    }
}