using AutoMapper;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.DTOs.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
