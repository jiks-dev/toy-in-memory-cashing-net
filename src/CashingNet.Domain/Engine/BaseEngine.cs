using Microsoft.Extensions.DependencyInjection;

namespace CashingNet.Domain.Engine
{
    public abstract class BaseEngine : IEngine
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BaseEngine(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public virtual async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope()) 
                {
                    await InitalizeAsync(scope.ServiceProvider);
                }

                while (cancellationToken.IsCancellationRequested == false)
                {
                    using (var scope = _serviceScopeFactory.CreateScope()) 
                    {
                        await StartCycleAsync(scope.ServiceProvider);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    await StopAsync(scope.ServiceProvider);
                }
            }
        }

        protected virtual Task InitalizeAsync(IServiceProvider serviceProvider)
        {
            return Task.CompletedTask;
        }

        protected virtual Task StopAsync(IServiceProvider serviceProvider)
        {
            return Task.CompletedTask;
        }

        protected abstract Task StartCycleAsync(IServiceProvider serviceProvider);
    }
}
