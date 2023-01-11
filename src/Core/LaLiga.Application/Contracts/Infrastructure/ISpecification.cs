using LaLiga.Domain.Common;
using System.Linq.Expressions;

namespace LaLiga.Application.Contracts.Infrastructure
{
    public interface ISpecification<TEntity> where TEntity : BaseDomainModel
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        IList<Expression<Func<TEntity, object>>> Include { get; }
    }
}
