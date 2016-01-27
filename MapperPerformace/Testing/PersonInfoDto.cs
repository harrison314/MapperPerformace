using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Dto represents <see cref="MapperPerformace.Ef.Person"/>.
    /// </summary>
    public class PersonInfoDto
    {
        public int BusinessEntityID
        {
            get;
            set;
        }

        public string PersonType
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public DateTime? EmployeeBrithDate
        {
            get;
            set;
        }

        public string EmployeeGender
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonInfoDto"/> class.
        /// </summary>
        public PersonInfoDto()
        {

        }
    }
}
