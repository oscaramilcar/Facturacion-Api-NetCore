using System;
using System.Collections.Generic;
using AutoMapper;
using Facturacion.API.Entities;
using Facturacion.API.DTO;
using Facturacion.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.API.Controllers
{
    [ApiController]
    [Route("api/clientes/{clienteId}/facturas")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public FacturasController(
            IFacturaRepository facturaRepository,
            IClienteRepository clienteRepository,
            IMapper mapper
        )
        {
            _facturaRepository = facturaRepository ?? throw new ArgumentNullException(nameof(facturaRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{facturaId}", Name = "GetFacturaForCliente")]
        public ActionResult<EncabezadoFacturaDTO> GetFacturaForCliente(int clienteId, int facturaId)
        {
            if(!_clienteRepository.ClienteExists(clienteId))
            {
                return NotFound();
            }
            var facturaForClienteFromRepo = _facturaRepository.GetFactura(clienteId,facturaId);
            if(facturaForClienteFromRepo == null)
            {
                return NotFound();
            }
            return _mapper.Map<EncabezadoFacturaDTO>(facturaForClienteFromRepo);
        }
        [HttpPost]
        public ActionResult<EncabezadoFacturaDTO> CreateFactura(int clienteId, EncabezadoFacturaForCreationDTO factura)
        {
            if (!_clienteRepository.ClienteExists(clienteId))
            {
                return NotFound();
            }
            var facturaEntity = _mapper.Map<EncabezadoFactura>(factura);
            _facturaRepository.AddFactura(clienteId, facturaEntity);
            _facturaRepository.Save();

            var facturaToReturn = _mapper.Map<EncabezadoFacturaDTO>(facturaEntity);
            return CreatedAtRoute("GetFacturaForCliente", 
            new { clienteId = clienteId, facturaId = facturaToReturn.Id }, facturaToReturn);
        }
        [HttpDelete("{facturaId}")]
        public ActionResult DeleteFactura(int clienteId, int facturaId)
        {
           if(!_clienteRepository.ClienteExists(clienteId))
           {
               return NotFound();
           }
           var facturaForClienteFromRepo = _facturaRepository.GetFactura(clienteId, facturaId);
           if(facturaForClienteFromRepo == null)
           {
               return NotFound();
           }
           _facturaRepository.DeleteFactura(facturaForClienteFromRepo);
           _facturaRepository.Save();

           return NoContent();
        }
    }
}