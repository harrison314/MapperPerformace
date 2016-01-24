using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapperPerformace.Ef;

namespace MapperPerformace.Adapters
{
    public class VanilaEfAdapter : IAdapter
    {
        private AdventureWorks2014Entities dbContext;

        public string Name
        {
            get
            {
                return "Entity Framework";
            }
        }

        public VanilaEfAdapter()
        {
            this.dbContext = null;
        }

        public void Relase()
        {
            this.dbContext?.Dispose();
            this.dbContext = null;
        }

        public List<PersonInfoDto> GetAllPersons()
        {
            IEnumerable<PersonInfoDto> projection =
                this.dbContext.People.OrderBy(t => t.ModifiedDate)
                .Select(t => new PersonInfoDto()
                {
                    BusinessEntityID = t.BusinessEntityID,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    PersonType = t.PersonType,
                    Title = t.Title,
                    EmployeeBrithDate = t.Employee.BirthDate,
                    EmployeeGender = t.Employee.Gender
                });


            List<PersonInfoDto> rezult = projection.ToList();
            return rezult;
        }

        public List<PersonInfoDto> GetPaggedPersons(int skip, int take)
        {
            IEnumerable<PersonInfoDto> projection =
                this.dbContext.People.OrderBy(t => t.ModifiedDate)
                .Skip(skip).Take(take)
                .Select(t => new PersonInfoDto()
                {
                    BusinessEntityID = t.BusinessEntityID,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    PersonType = t.PersonType,
                    Title = t.Title,
                    EmployeeBrithDate = t.Employee.BirthDate,
                    EmployeeGender = t.Employee.Gender
                });


            List<PersonInfoDto> rezult = projection.ToList();
            return rezult;
        }

        public void Prepare()
        {
            this.dbContext = new AdventureWorks2014Entities();
        }
    }
}
