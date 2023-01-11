using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Infrastructure.Persistence;
using LaLiga.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaLiga.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("CatalogConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
