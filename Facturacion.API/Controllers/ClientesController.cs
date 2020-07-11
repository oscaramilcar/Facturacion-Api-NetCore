using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Facturacion.API.Entities;
using Facturacion.API.DTO;
using Facturacion.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Facturacion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClientesController(
            IClienteRepository clienteRepository,
            IMapper mapper
            )
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clientesFromRepo =  _clienteRepository.GetClientes();
            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(clientesFromRepo));
        }
        [HttpGet("{clienteId}", Name="getCliente")]
        public ActionResult<ClienteDTO> getCliente(int clienteId)
        {
            var clienteFromRepo = _clienteRepository.GetCliente(clienteId);
            if(clienteFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClienteDTO>(clienteFromRepo));
        }

        [HttpPost]
        public ActionResult<ClienteDTO> CreateCliente(ClienteForCreationDTO cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            _clienteRepository.AddCliente(clienteEntity);
            _clienteRepository.Save();

            var clienteToReturn = _mapper.Map<ClienteDTO>(clienteEntity);

            return CreatedAtRoute("getCliente", new { clienteId = clienteToReturn.Id }, clienteToReturn);
        }
        [HttpPut("{clienteId}")]
        public ActionResult UpdateCliente(int clienteId, ClienteForUpdateDTO cliente)
        {
            if(!_clienteRepository.ClienteExists(clienteId))
            {
                return NotFound();
            }
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            _clienteRepository.UpdateCliente(clienteId, clienteEntity);
            _clienteRepository.Save();

            return NoContent();
        }
        [HttpDelete("{clienteId}")]
        public ActionResult DeleteCliente(int clienteId)
        {
            var clienteFromRepo = _clienteRepository.GetCliente(clienteId);
            if(clienteFromRepo == null)
            {
                return NotFound();
            }
            _clienteRepository.DeleteCliente(clienteFromRepo);
            _clienteRepository.Save();

            return NoContent();
        }
    }
}
