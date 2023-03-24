using AutoMapper;
using ProductApp.Domain.Entities;
using ProductApp.WebApi.ViewModels;

namespace ProductApp.WebApi.Mappings;
public class MappingProfile : Profile {
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
    }
}
