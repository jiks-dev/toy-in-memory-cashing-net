using CashingNet.Domain.Factories;
using Microsoft.Extensions.Caching.Memory;

namespace CashingNet.Domain.Services.Caches
{
    public class EntityCacheManager : IEntityCacheManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICasheOptionFactory _casheOptionFactory;
        private Dictionary<string, object> _entities;

        public EntityCacheManager(
            IMemoryCache memoryCache,
            IEntityCasheFactory casheFactory,
            ICasheOptionFactory casheOptionFactory)
        {
            _memoryCache = memoryCache;
            _casheOptionFactory = casheOptionFactory;
            _entities = casheFactory.Produce();

            foreach (var entity in _entities)
            {   
                _memoryCache.Set(entity.Key, entity.Value, _casheOptionFactory.Produce());
            }
        }

        public void Set<TEntity>(TEntity value, string key = "")
        {
            if (String.IsNullOrWhiteSpace(key)) 
            {
                key = typeof(TEntity).Name;
            }

            if (_memoryCache.TryGetValue(key, out _) == false) 
            {
                throw new Exception();
            }

            _memoryCache.Set(key, value, _casheOptionFactory.Produce());
        }

        public TEntity Get<TEntity>(string key = "")
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                key = typeof(TEntity).Name;
            }

            if (_memoryCache.TryGetValue(key, out TEntity value) == false)
            {
                throw new Exception();
            }

            return value;
        }
    }
}
