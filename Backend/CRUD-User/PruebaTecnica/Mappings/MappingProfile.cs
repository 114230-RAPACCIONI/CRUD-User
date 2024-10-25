using AutoMapper;
using PruebaTecnica.Dtos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}