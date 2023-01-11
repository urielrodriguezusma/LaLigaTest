using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LaLiga.Infrastructure.Repositories
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseDomainModel
    {
        public static IQueryable<TEntity> Evaluate(IQueryable<TEntity> query, ISpecification<TEntity> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Include.Count > 0)
            {
                query = spec.Include.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            }

            return query;
        }
    }
}
