using AutoMapper;
using LaLiga.Application.Dto;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            this.CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductId, src => src.MapFrom(p => p.Id))
                .ForMember(d => d.ProductName, src => src.MapFrom(p => p.Name))
                .ForMember(d => d.CategoryId, src => src.MapFrom(p => p.CategoryId))
                .ForMember(d => d.CategoryName, src => src.MapFrom(p => p.Category.CategoryName))
                .ReverseMap();
        }
    }
}
