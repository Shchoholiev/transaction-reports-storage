using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionReportsStorage.Application.Interfaces;
using TransactionReportsStorage.Application.Interfaces.Repositories;
using TransactionReportsStorage.Infrastructure.EF;
using TransactionReportsStorage.Infrastructure.Repositories;
using TransactionReportsStorage.Infrastructure.Services;

namespace TransactionReportsStorage.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
                                                           IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLDataBase");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRecordsService, RecordsService>();

            return services;
        }
    }
}
