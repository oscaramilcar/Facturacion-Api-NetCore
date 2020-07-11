using AutoMapper;

namespace Facturacion.API.Profiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<Entities.EncabezadoFactura,DTO.EncabezadoFacturaDTO>();
            CreateMap<DTO.EncabezadoFacturaForCreationDTO,Entities.EncabezadoFactura>();
        }
    }
}