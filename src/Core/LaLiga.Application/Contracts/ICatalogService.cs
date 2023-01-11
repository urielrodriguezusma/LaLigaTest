using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Contracts
{
    public interface ICatalogService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync();
        Task<IReadOnlyList<ProductDto>> GetProductsWithSpecAsync(ProductWithCategorySpecification spec);
    }
}
