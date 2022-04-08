using Microsoft.Extensions.Caching.Memory;

namespace CashingNet.Domain.Factories
{
    public interface ICasheOptionFactory
    {
        MemoryCacheEntryOptions Produce();
    }
}
