using System;
using AutoMapper;

namespace Facturacion.API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Entities.Cliente,DTO.ClienteDTO>();
            CreateMap<DTO.ClienteForCreationDTO,Entities.Cliente>();
            CreateMap<DTO.ClienteForUpdateDTO,Entities.Cliente>();
        }
    }
}