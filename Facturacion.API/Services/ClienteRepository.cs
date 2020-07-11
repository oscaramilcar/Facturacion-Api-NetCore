using Facturacion.API.Context;
using Facturacion.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Services
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly FacturacionContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        public ClienteRepository(
            FacturacionContext context,
            ILogger<ClienteRepository> logger
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddCliente(Cliente cliente)
        {
            if(cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            _context.Add(cliente);
        }

        public Cliente GetCliente(int id)
        {
            return _context.Clientes.Include(e => e.Facturas).ThenInclude(i => i.ItemFacturas).ThenInclude(p => p.Producto).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.Include(e => e.Facturas).ThenInclude(i => i.ItemFacturas).ThenInclude(p => p.Producto).ToList();
        }
        public void UpdateCliente(int clienteId, Cliente cliente)
        {
            cliente.Id = clienteId;
            _context.Clientes.Update(cliente);
        }
        public bool ClienteExists(int idCliente)
        {
            return _context.Clientes.Any(c => c.Id == idCliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
