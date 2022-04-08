using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashingNet.Domain.Factories
{
    public interface IEntityCasheFactory
    {
        Dictionary<string, object> Produce();
    }
}
