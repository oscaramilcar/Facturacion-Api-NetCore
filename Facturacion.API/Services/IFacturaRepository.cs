using Facturacion.API.Entities;

namespace Facturacion.API.Services
{
    public interface IFacturaRepository
    {
        void AddFactura(int clienteId, EncabezadoFactura factura);
        bool Save();
        EncabezadoFactura GetFactura(int clienteId, int facturaId);
        void DeleteFactura(EncabezadoFactura factura);
    }
}