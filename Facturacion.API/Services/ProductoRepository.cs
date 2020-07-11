using System;
using System.Collections.Generic;
using System.Linq;
using Facturacion.API.Context;
using Facturacion.API.Entities;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Services
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly FacturacionContext _context;
        private readonly ILogger<ProductoRepository> _logger;
        public ProductoRepository(
            FacturacionContext context,
            ILogger<ProductoRepository> logger
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));         
        }
        public IEnumerable<Producto> GetProductos(string nombre)
        {
            if(string.IsNullOrWhiteSpace(nombre))
            {
                return _context.Productos.ToList<Producto>();
            }
            nombre = nombre.Trim();
            var matchProducto = from p in _context.Productos where p.Nombre.Contains(nombre) select p;
            return matchProducto;
        }
    }
}