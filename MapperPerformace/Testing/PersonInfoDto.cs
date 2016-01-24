using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// POCO class for short personal informations.
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

        public PersonInfoDto()
        {

        }
    }
}
