using AutoMapper;

namespace Facturacion.API.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Entities.Producto,DTO.ProductoDTO>();
            CreateMap<DTO.ProductoForCreationDTO,Entities.Producto>();
        }
    }
}