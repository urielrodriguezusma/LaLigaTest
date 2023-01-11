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
                .ForMember(d => d.ProductName, src => src.MapFrom(p => p.Name))
                .ForMember(d => d.Category, src => src.MapFrom(p => p.Category.CategoryName));

        }
    }
}
