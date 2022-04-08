using CashingNet.Domain.Entities;

namespace CashingNet.Domain.Factories
{
    public class EntityCasheFactory : IEntityCasheFactory
    {
        private readonly ExampleFactory _factory;

        public EntityCasheFactory(ExampleFactory factory)
        {
            _factory = factory;
        }

        public Dictionary<string, object> Produce()
        {
            return new Dictionary<string, object>()
            {
                { typeof(Example).Name, _factory.Produce(1, DateTime.Now)}
            };
        }
    }
}
