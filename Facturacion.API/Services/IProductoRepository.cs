using System.Collections.Generic;
using Facturacion.API.Entities;

namespace Facturacion.API.Services
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetProductos(string nombre);
    }
}