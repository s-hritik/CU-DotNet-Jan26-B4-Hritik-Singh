using AutoMapper;
using ApiService.DTOs;
using ApiService.Models;

namespace ApiService.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>()
         .ForMember(dest => dest.ImageUrl,
            opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice ?? 0m))
            .ForMember(dest => dest.UnitsInStock,
                opt => opt.MapFrom(src => src.UnitsInStock ?? (short)0));
    }
}
