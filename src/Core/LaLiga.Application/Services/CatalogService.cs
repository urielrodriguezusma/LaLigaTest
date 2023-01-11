using AutoMapper;
using LaLiga.Application.Contracts;
using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork<Product> unitOfWork;
        private readonly IMapper mapper;

        public CatalogService(IUnitOfWork<Product> unitOfWork,
                             IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var products = await this.unitOfWork.GetRepository().GetAllAsync();
            if (products != null)
            {
                return this.mapper.Map<IReadOnlyList<ProductDto>>(products);
            }
            return null;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsWithSpecAsync(ProductWithCategorySpecification spec)
        {
            var products = await this.unitOfWork.GetRepository().GetAllWithSpecAsync(spec);
            if (products != null)
            {
                return this.mapper.Map<IReadOnlyList<ProductDto>>(products);
            }
            return null;
        }
    }
}
