using LaLiga.Domain.Model;

namespace LaLiga.Application.Contracts
{
    public interface ICatalogService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
