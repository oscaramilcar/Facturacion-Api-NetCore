using Facturacion.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.API.Services
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        void AddCliente(Cliente cliente);
        void UpdateCliente(int clienteId, Cliente cliente);
        Cliente GetCliente(int id);
        void DeleteCliente(Cliente cliente);
        bool Save();
        bool ClienteExists(int idCliente);
    }
}
