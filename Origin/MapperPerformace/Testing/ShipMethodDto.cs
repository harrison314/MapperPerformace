using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Dto represents <see cref="MapperPerformace.Ef.ShipMethod"/>.
    /// </summary>
    /// <remarks>
    /// Find by id between 1 and 5.
    /// </remarks>
    public class ShipMethodDto
    {
        public int ShipMethodID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal ShipBase
        {
            get;
            set;
        }

        public decimal ShipRate
        {
            get;
            set;
        }

        public Guid rowguid
        {
            get;
            set;
        }

        public DateTime ModifiedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipMethodDto"/> class.
        /// </summary>
        public ShipMethodDto()
        {

        }
    }
}
