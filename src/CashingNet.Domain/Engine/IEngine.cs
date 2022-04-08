namespace CashingNet.Domain.Engine
{
    public interface IEngine
    {
        Task RunAsync(CancellationToken cancellationToken);
    }
}
