using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;

namespace LaLiga.Application.Contracts
{
    public interface ICatalogService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync();
        Task<IReadOnlyList<ProductDto>> GetProductsWithSpecAsync(ProductWithCategorySpecification spec);
        Task<ProductDto> GetProductsByIdWithSpecAsync(ProductWithCategorySpecification spec);
    }
}
