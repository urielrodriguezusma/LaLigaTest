using LaLiga.Domain.Common;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;
    }
}
