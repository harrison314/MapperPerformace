using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Testing adapter interface.
    /// </summary>
    public interface IAdapter
    {
        /// <summary>
        /// Gets the mapper name.
        /// </summary>
        /// <value>
        /// The mapper name.
        /// </value>
        string Name
        {
            get;
        }

        /// <summary>
        /// Prepares this mapper fo use.
        /// </summary>
        void Prepare();

        /// <summary>
        /// Relases used internal reourse.
        /// </summary>
        void Relase();

        /// <summary>
        /// Gets all persons from databse.
        /// </summary>
        /// <returns></returns>
        List<PersonInfoDto> GetAllPersons();

        List<PersonInfoDto> GetPaggedPersons(int skip, int take);

    }
}
