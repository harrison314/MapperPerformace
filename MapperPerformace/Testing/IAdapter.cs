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

        /// <summary>
        /// Gets the pagged persons.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<PersonInfoDto> GetPaggedPersons(int skip, int take);

        // TODO: Pridat select cez Id, na 
        //       - objekt s dovama kolekciami entit
        //       - jednoduchy objekt podla id
        //       - jednoduchy ojekt s vnorenym objektom
        //       - Select N+1 problem
        // http://stackoverflow.com/questions/20492071/simple-inner-join-result-with-dapper

    }
}
