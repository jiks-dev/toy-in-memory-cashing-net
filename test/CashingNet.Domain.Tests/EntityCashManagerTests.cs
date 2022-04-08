using CashingNet.Domain.Entities;
using CashingNet.Domain.Factories;
using CashingNet.Domain.Services.Caches;
using CashingNet.Domain.Tests.Factoies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace CashingNet.Domain.Tests
{
    public class EntityCashManagerTests
    {
        private readonly IHost _host;

        public EntityCashManagerTests()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMemoryCache();
                    services.AddSingleton<ExampleFactory>();
                    services.AddSingleton<ICasheOptionFactory, DefaultCasheOptionFactory>();
                    services.AddSingleton<IEntityCasheFactory, TestEntityCasheFactory>();
                    services.AddSingleton<IEntityCacheManager, EntityCacheManager>();
                })
                .Build();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void KeyAndValueAreSavedNormally(string id) 
        {
            using var serviceScope = _host.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            var manager = serviceProvider.GetRequiredService<IEntityCacheManager>();

            var getExample1 = manager.Get<Example>(id);
            Assert.Equal(1, getExample1.Sequence);

            var setExample2 = getExample1.Clone();
            Assert.Equal(2, setExample2.Sequence);

            manager.Set(setExample2, id);

            var getExample2 = manager.Get<Example>(id);
            Assert.Equal(2, getExample2.Sequence);
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("2", "3")]
        [InlineData("3", "1")]
        public void keysDoNotAffectExclusively(string id1, string id2)
        {
            using var serviceScope = _host.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;
            var manager = serviceProvider.GetRequiredService<IEntityCacheManager>();

            var getExampleId1Seq1 = manager.Get<Example>(id1);
            Assert.Equal(1, getExampleId1Seq1.Sequence);
            var getExampleId2Seq2 = manager.Get<Example>(id2);
            Assert.Equal(1, getExampleId2Seq2.Sequence);

            manager.Set(getExampleId1Seq1.Clone(), id1);
            manager.Set(getExampleId2Seq2.Clone().Clone(), id2);

            var getExampleId1Seq2 = manager.Get<Example>(id1);
            Assert.Equal(2, getExampleId1Seq2.Sequence);
            var getExampleId2Seq3 = manager.Get<Example>(id2);
            Assert.Equal(3, getExampleId2Seq3.Sequence);
        }
    }
}
