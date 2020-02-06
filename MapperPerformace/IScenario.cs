using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace
{
    public interface IScenario
    {
        ValueTask<object> SqlClient();

        ValueTask<object> Dapper();

        ValueTask<object> EfCore();

        ValueTask<object> EfCoreAsNoTracking();
    }
}
