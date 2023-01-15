using LaLiga.Application.Dto;
using LaLiga.Application.Helpers;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Common;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Contracts
{
    public interface ICatalogService
    {
        Task<PagedList<ProductDto>> GetProductsAsync(UserParams userParams);
        Task<PagedList<ProductDto>> GetProductsWithSpecAsync(UserParams userParams,ProductWithCategorySpecification spec);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> GetProductsByIdWithSpecAsync(ProductWithCategorySpecification spec);
        Task<ProductDto> CreateProductAsync(ProductToCreate newProduct);
        Task<ProductDto> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductByIdAsync(int id);
    }
}
