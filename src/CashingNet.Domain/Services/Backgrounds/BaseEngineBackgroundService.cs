using CashingNet.Domain.Engine;
using Microsoft.Extensions.Hosting;

namespace CashingNet.Domain.Services.Backgrounds
{
    public class BaseEngineBackgroundService : BackgroundService
    {
        private readonly IEngine _engine;

        public BaseEngineBackgroundService(IEngine engine)
        {
            _engine = engine;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false) 
            {
                try
                {
                    await _engine.RunAsync(stoppingToken);
                }
                catch 
                {
                    // TODO : (dh) write dump.
                }

                await Task.Delay(2000);
            }
        }
    }
}
