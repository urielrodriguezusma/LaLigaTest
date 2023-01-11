using LaLiga.Domain.Common;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainModel
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveEntity(TEntity entity);
    }
}
