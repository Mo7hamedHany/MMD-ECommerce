using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Repositories.Implementations;
using StackExchange.Redis;

namespace MMD_ECommerce.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnection"));

                return ConnectionMultiplexer.Connect(config);
            });

            services.AddScoped<IBasketRepository, BasketRepository>();


            return services;
        }
    }
}
