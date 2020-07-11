using System;
using System.Collections.Generic;
using System.Linq;
using Facturacion.API.Context;
using Facturacion.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Services
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FacturacionContext _context;
        private readonly ILogger<FacturaRepository> _logger;
        public FacturaRepository(
            FacturacionContext context,
            ILogger<FacturaRepository> logger
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }
        public void DeleteFactura(EncabezadoFactura factura)
        {
            _context.EncabezadoFacturas.Remove(factura);
        }
        public void AddFactura(int clienteId, EncabezadoFactura factura)
        {
            factura.ClienteId = clienteId;
            factura.CreateAt = DateTime.Now;
            
            List<ItemFactura> items = new List<ItemFactura>();

            foreach(var item in factura.ItemFacturas)
            {
                var pedido = new ItemFactura()
                {
                    Cantidad = item.Cantidad,
                    ProductoId = item.Producto.Id,
                };
                items.Add(pedido);
            }
            factura.ItemFacturas = items;
            _context.EncabezadoFacturas.Add(factura);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public EncabezadoFactura GetFactura(int clienteId, int facturaId)
        {
            return _context.EncabezadoFacturas.
            Where(x => x.ClienteId == clienteId && x.Id == facturaId).
            Include(c => c.Cliente).Include(i => i.ItemFacturas).ThenInclude(p => p.Producto).FirstOrDefault();
        }
    }
}