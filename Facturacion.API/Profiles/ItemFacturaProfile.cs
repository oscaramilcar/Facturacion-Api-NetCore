using AutoMapper;

namespace Facturacion.API.Profiles
{
    public class ItemFacturaProfile : Profile
    {
        public ItemFacturaProfile()
        {
            CreateMap<Entities.ItemFactura, DTO.ItemFacturaDTO>()
                .ForMember(
                    dest => dest.Importe,
                    opt => opt.MapFrom(src => src.Producto.Precio * src.Cantidad)
                );
            CreateMap<DTO.ItemForCreationDTO, Entities.ItemFactura>();
        }
    }
}