using LaLiga.Application.Helpers;
using LaLiga.Domain.Common;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainModel
    {
        Task<PagedList<TEntity>> GetAllAsync(UserParams userParams);
        Task<PagedList<TEntity>> GetAllWithSpecAsync(UserParams userParams, ISpecification<TEntity> spec);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity> spec);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveEntity(TEntity entity);
    }
}
