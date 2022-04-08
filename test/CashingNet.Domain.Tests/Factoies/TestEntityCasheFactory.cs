using CashingNet.Domain.Factories;
using System;
using System.Collections.Generic;

namespace CashingNet.Domain.Tests.Factoies
{
    public class TestEntityCasheFactory : IEntityCasheFactory
    {
        private readonly ExampleFactory _factory;

        public TestEntityCasheFactory(ExampleFactory factory)
        {
            _factory = factory;
        }

        public Dictionary<string, object> Produce()
        {
            return new Dictionary<string, object>()
            {
                { "1", _factory.Produce( 1, new DateTime(2022, 01, 01)) },
                { "2", _factory.Produce( 2, new DateTime(2022, 01, 01)) },
                { "3", _factory.Produce( 3, new DateTime(2022, 01, 01)) },
            };
        }
    }
}
