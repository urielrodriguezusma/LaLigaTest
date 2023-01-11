using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Domain.Common;
using System.Linq.Expressions;

namespace LaLiga.Application.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseDomainModel
    {
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }
        public IList<Expression<Func<TEntity, object>>> Include { get; private set; } = new List<Expression<Func<TEntity, object>>>();
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            this.Criteria = criteria;
        }

        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            this.Include.Add(include);
        }
    }
}
