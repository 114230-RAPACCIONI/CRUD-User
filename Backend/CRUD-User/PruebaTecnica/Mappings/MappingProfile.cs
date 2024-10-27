using AutoMapper;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Mappings;

/*
 * Clase para Mapear los objetos.
 */
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
    }
}