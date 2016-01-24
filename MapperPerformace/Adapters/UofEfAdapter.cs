using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapperPerformace.Ef;

namespace MapperPerformace.Adapters
{
    public class UofEfAdapter : IAdapter
    {


        public string Name
        {
            get
            {
                return "Entity Framework - UoF";
            }
        }

        public UofEfAdapter()
        {

        }

        public void Relase()
        {

        }

        public List<PersonInfoDto> GetAllPersons()
        {
            using (AdventureWorks2014Entities dbContext = new AdventureWorks2014Entities())
            {
                IEnumerable<PersonInfoDto> projection =
                    dbContext.People.OrderBy(t => t.ModifiedDate)
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
        }

        public List<PersonInfoDto> GetPaggedPersons(int skip, int take)
        {
            using (AdventureWorks2014Entities dbContext = new AdventureWorks2014Entities())
            {
                IEnumerable<PersonInfoDto> projection =
                dbContext.People.OrderBy(t => t.ModifiedDate)
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
        }

        public void Prepare()
        {
            
        }
    }
}
