using Facturacion.API.Entities;

namespace Facturacion.API.DTO
{
    public class ItemFacturaDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public ProductoDTO Producto { get; set; }
        public decimal Importe{ get; set;}
    }
}