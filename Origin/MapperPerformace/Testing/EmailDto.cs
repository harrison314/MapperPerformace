using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Dto class represents <see cref="MapperPerformace.Ef.EmailAddress"/>. 
    /// </summary>
    public class EmailDto
    {
        public int EmailAddressID
        {
            get;
            set;
        }

        public string EmailAddress
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
        /// Initializes a new instance of the <see cref="EmailDto"/> class.
        /// </summary>
        public EmailDto()
        {

        }
    }
}
