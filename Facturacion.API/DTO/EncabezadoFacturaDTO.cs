using System;
using System.Collections.Generic;

namespace Facturacion.API.DTO
{
    public class EncabezadoFacturaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public ClienteDTO Cliente { get; set; }
        public ICollection<ItemFacturaDTO> ItemFacturas { get; set; } = new List<ItemFacturaDTO>();
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in ItemFacturas)
                {
                    total += item.Importe;
                }
                return total;
            }
        }
    }
}