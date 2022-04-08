namespace CashingNet.Domain.Services.Caches
{
    public interface IEntityCacheManager
    {
        void Set<TEntity>(TEntity value, string key = "");
        TEntity Get<TEntity>(string key = "");
    }
}
