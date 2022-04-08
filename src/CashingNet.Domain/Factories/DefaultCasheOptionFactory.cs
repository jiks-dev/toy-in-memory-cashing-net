using Microsoft.Extensions.Caching.Memory;

namespace CashingNet.Domain.Factories
{
    public class DefaultCasheOptionFactory : ICasheOptionFactory
    {
        public MemoryCacheEntryOptions Produce()
        {
            var options = new MemoryCacheEntryOptions()
                .SetSize(1)
                .SetPriority(CacheItemPriority.NeverRemove);

            return options;
        }
    }
}
