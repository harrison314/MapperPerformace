using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Find by id  1-5
    /// </summary>
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

        public ShipMethodDto()
        {

        }

    }
}
