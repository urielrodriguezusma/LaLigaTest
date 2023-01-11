using Microsoft.EntityFrameworkCore;
using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Domain.Common;
using LaLiga.Infrastructure.Persistence;

namespace LaLiga.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainModel
    {
        private readonly CatalogContext context;

        public GenericRepository(CatalogContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec)
        {
            var querySpecificationResult = ApplySpecEvaluator(spec);
            return await querySpecificationResult.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.context.Set<TEntity>().FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity> spec)
        {
            var querySpecificationResult = ApplySpecEvaluator(spec);
            return await querySpecificationResult.FirstOrDefaultAsync();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task RemoveEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        private IQueryable<TEntity> ApplySpecEvaluator(ISpecification<TEntity> spec)
        {
            IQueryable<TEntity> query = this.context.Set<TEntity>().AsQueryable();
            var queryResult = SpecificationEvaluator<TEntity>.Evaluate(query, spec);
            return queryResult;
        }
    }
}
