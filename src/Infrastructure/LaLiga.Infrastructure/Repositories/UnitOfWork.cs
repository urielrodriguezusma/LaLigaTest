using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Domain.Common;
using LaLiga.Infrastructure.Persistence;
using System.Collections;

namespace LaLiga.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext catalogContext;
        private Hashtable hashtable;

        public UnitOfWork(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel
        {
            var entityType = typeof(TEntity);
            if (hashtable == null)
                hashtable = new Hashtable();

            var entityName = entityType.Name;
            if (!hashtable.ContainsKey(entityName))
            {
                var genericRepo = typeof(GenericRepository<>);
                var genericIntance = Activator.CreateInstance(genericRepo.MakeGenericType(entityType), catalogContext);
                hashtable[entityName] = genericIntance;
            }

            return (IGenericRepository<TEntity>)hashtable[entityName];
        }
    }
}
