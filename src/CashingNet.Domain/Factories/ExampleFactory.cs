using CashingNet.Domain.Entities;

namespace CashingNet.Domain.Factories
{
    public class ExampleFactory
    {
        public Example Produce(int id, DateTime dateTime)
        {
            return new Example()
            {
                Id = id,
                Sequence = 1,
                Created = dateTime
            };
        }
    }
}
