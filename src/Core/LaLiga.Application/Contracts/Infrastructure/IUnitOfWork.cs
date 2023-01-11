using LaLiga.Domain.Common;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface IUnitOfWork<TEntity> where TEntity : BaseDomainModel
    {
        IGenericRepository<TEntity> GetRepository();
    }
}
