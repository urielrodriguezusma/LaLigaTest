using LaLiga.Domain.Common;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainModel
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity> spec);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveEntity(TEntity entity);
    }
}
