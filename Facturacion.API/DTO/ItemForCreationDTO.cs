namespace Facturacion.API.DTO
{
    public class ItemForCreationDTO
    {
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public ProductoForCreationDTO Producto { get; set; }
    }
}