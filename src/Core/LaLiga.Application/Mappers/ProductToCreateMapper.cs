using AutoMapper;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Mappers
{
    public class ProductToCreateMapper : Profile
    {
        public ProductToCreateMapper()
        {
            CreateMap<ProductToCreate, Product>()
                    .ForMember(d => d.Name, src => src.MapFrom(p => p.ProductName));
        }
    }
}
