using Microsoft.EntityFrameworkCore;
using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Domain.Common;
using LaLiga.Infrastructure.Persistence;
using LaLiga.Application.Helpers;

namespace LaLiga.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainModel
    {
        private readonly CatalogContext context;
        public GenericRepository(CatalogContext context)
        {
            this.context = context;
        }

        public async Task<PagedList<TEntity>> GetAllAsync(UserParams userParams)
        {
            var pagedList = await PagedList<TEntity>.CreateAsync(this.context.Set<TEntity>(), userParams.PageNumber, userParams.PageSize);
            return pagedList;
        }

        public async Task<PagedList<TEntity>> GetAllWithSpecAsync(UserParams userParams, ISpecification<TEntity> spec)
        {
            var querySpecificationResult = ApplySpecEvaluator(spec);
            return await PagedList<TEntity>.CreateAsync(querySpecificationResult, userParams.PageNumber, userParams.PageSize);
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

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await this.context.Set<TEntity>().AddAsync(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return entity;
        }
        public async Task RemoveEntity(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            await this.context.SaveChangesAsync();
        }

        private IQueryable<TEntity> ApplySpecEvaluator(ISpecification<TEntity> spec)
        {
            IQueryable<TEntity> query = this.context.Set<TEntity>().AsQueryable();
            var queryResult = SpecificationEvaluator<TEntity>.Evaluate(query, spec);
            return queryResult;
        }
    }
}
