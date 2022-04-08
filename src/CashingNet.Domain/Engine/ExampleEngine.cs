using CashingNet.Domain.Entities;
using CashingNet.Domain.Services.Caches;
using Microsoft.Extensions.DependencyInjection;

namespace CashingNet.Domain.Engine
{
    public class ExampleEngine : BaseEngine
    {
        public ExampleEngine(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
               await base.RunAsync(cancellationToken);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override async Task StartCycleAsync(IServiceProvider serviceProvider)
        {
            var cacheManager = serviceProvider.GetRequiredService<IEntityCacheManager>();

            var example = cacheManager.Get<Example>();
            cacheManager.Set<Example>(example.Clone());
            await Task.Delay(1000);
        }
    }
}
