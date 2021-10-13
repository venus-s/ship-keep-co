using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipKeepCo.Application.Interfaces;
using ShipKeepCo.Infrastructure.Repositories;
using System.Reflection;

namespace ShipKeepCo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var migrationAssembly = typeof(ShipKeepCoContext).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ShipKeepCoContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlite => sqlite.MigrationsAssembly(migrationAssembly)));

            services.AddTransient<IShipKeepCoRepository, ShipKeepCoRepository>();

            return services;
        }
    }
}
