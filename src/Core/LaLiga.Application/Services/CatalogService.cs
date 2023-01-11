using LaLiga.Application.Contracts;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Services
{
    public class CatalogService : ICatalogService
    {
        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
