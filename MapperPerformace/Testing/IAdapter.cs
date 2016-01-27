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
        /// Load large list of entities from database.
        /// </summary>
        /// <returns></returns>
        List<PersonInfoDto> GetAllPersons();

        /// <summary>
        /// Gets the pagged persons.
        /// Load paged list of entities.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<PersonInfoDto> GetPagedPersons(int skip, int take);

        /// <summary>
        /// Gets the  Ship method from database by Id.
        /// Load one row  by Id wit simple mapping.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ShipMethodDto GetSimple(int id);

        /// <summary>
        /// Gets the product with price history by Id.
        /// Load one row with history as list.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        ProductDto GetProduct(int i);

        /// <summary>
        /// Gets the product with product model by Id.
        /// Load one rowwith joined object.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Product2Dto GetProduct2(int id);

        // TODO: Pridat select cez Id, na 
        //       - objekt s dovama kolekciami entit ok
        //       - jednoduchy ojekt s vnorenym objektom
        //       - Select N+1 problem
        // http://stackoverflow.com/questions/20492071/simple-inner-join-result-with-dapper

    }
}
