using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.API.DTO
{
    public class EncabezadoFacturaForCreationDTO
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public ICollection<ItemForCreationDTO> ItemFacturas { get; set; } = new List<ItemForCreationDTO>();

    }
}