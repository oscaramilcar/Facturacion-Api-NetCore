using System.ComponentModel.DataAnnotations;

namespace Facturacion.API.DTO
{
    public class ClienteForCreationDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}