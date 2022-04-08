using CashingNet.Domain.Engine;
using CashingNet.Domain.Factories;
using CashingNet.Domain.Services.Backgrounds;
using CashingNet.Domain.Services.Caches;

namespace CashingNet.API.Extensions
{
    public static class SystemServiceExtension
    {
        public static IServiceCollection AddSystemServices(this IServiceCollection services) 
        {
            services.AddMemoryCache();
            services.AddSingleton<ExampleFactory>();
            services.AddSingleton<ICasheOptionFactory, DefaultCasheOptionFactory>();
            services.AddSingleton<IEntityCasheFactory, EntityCasheFactory>();
            services.AddSingleton<IEntityCacheManager, EntityCacheManager>();

            services.AddSingleton<ExampleEngine>();
            services.AddSingleton<ExampleEngineBackgroundService>();
            services.AddHostedService<ExampleEngineBackgroundService>();

            return services;
        }
    }
}
