using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    public interface IAdapter
    {
        string Name
        {
            get;
        }

        void Prepare();

        void Relase();

        List<PersonInfoDto> GetAllPersons();

    }
}
