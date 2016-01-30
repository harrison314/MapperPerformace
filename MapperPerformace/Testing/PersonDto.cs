using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Dto reprints <see cref="MapperPerformace.Ef.Person"/>
    /// </summary>
    public class PersonDto
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

        public string MiddleName
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

        public List<string> TelephoneNumbers
        {
            get;
            set;
        }

        public List<EmailDto> Emails
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDto"/> class.
        /// </summary>
        public PersonDto()
        {

        }
    }
}
