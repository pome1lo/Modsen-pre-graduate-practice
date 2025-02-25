using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        MapCategory();
    }

    private void MapCategory()
    {
        CreateMap<Categories, CategoryDto>(MemberList.Destination);

        CreateMap<CategoryDto, Categories>(MemberList.Destination)
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore());
    }
}
