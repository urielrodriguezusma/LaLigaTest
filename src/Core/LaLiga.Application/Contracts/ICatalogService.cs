using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Contracts
{
    public interface ICatalogService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync();
        Task<IReadOnlyList<ProductDto>> GetProductsWithSpecAsync(ProductWithCategorySpecification spec);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> GetProductsByIdWithSpecAsync(ProductWithCategorySpecification spec);
        Task<ProductDto> CreateProductAsync(ProductToCreate newProduct);
        Task<ProductDto> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductByIdAsync(int id);
    }
}
