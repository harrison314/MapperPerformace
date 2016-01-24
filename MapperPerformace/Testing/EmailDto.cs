using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
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


        public EmailDto()
        {
            
        }
    }
}
