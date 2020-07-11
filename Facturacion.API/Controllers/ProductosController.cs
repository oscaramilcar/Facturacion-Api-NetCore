using System.Collections.Generic;
using AutoMapper;
using Facturacion.API.DTO;
using Facturacion.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductosController(
            IProductoRepository productoRepository,
            IMapper mapper
        )
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<ProductoDTO>> GetProductos(string nombre)
        {
            var productoFromRepo = _productoRepository.GetProductos(nombre);
            return Ok(_mapper.Map<IEnumerable<ProductoDTO>>(productoFromRepo));
        }

    }
}