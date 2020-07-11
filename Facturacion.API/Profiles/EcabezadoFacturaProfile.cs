using AutoMapper;

namespace Facturacion.API.Profiles
{
    public class EcabezadoFacturaProfile : Profile
    {
        public EcabezadoFacturaProfile()
        {
            CreateMap<Entities.EncabezadoFactura, DTO.EncabezadoFacturaDTO>();
            CreateMap<DTO.EncabezadoFacturaDTO, Entities.EncabezadoFactura>();
        }
    }
}