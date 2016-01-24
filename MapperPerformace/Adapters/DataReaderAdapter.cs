using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Adapters
{
    public class DataReaderAdapter : IAdapter
    {
        private string connectionString;
        private SqlConnection connection;

        public string Name
        {
            get
            {
                return "Date Reader";
            }
        }

        public DataReaderAdapter(Settings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            this.connectionString = settings.ConnectionString;
        }

        public void Relase()
        {
            this.connection?.Dispose();
            this.connection = null;
        }

        public List<PersonInfoDto> GetAllPersons()
        {
            string sql = @"SELECT p.[BusinessEntityID]
      ,[PersonType]
      ,[Title]
      ,[FirstName]
      ,[LastName]
	  ,e.[BirthDate] AS [EmployeeBrithDate]
	  ,e.[Gender] AS [EmployeeGender]
  FROM [AdventureWorks2014].[Person].[Person] p
  LEFT JOIN [AdventureWorks2014].[HumanResources].[Employee] e 
  ON p.[BusinessEntityID] = e.[BusinessEntityID]
  ORDER BY p.[ModifiedDate];";

            SqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            List<PersonInfoDto> results = new List<PersonInfoDto>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    PersonInfoDto personInfo = new PersonInfoDto();
                    personInfo.BusinessEntityID = Convert.ToInt32(reader["BusinessEntityID"]);
                    personInfo.EmployeeBrithDate = this.MapToDateTime(reader, "EmployeeBrithDate");
                    personInfo.EmployeeGender = this.MapToString(reader, "EmployeeGender");
                    personInfo.FirstName = this.MapToString(reader, "FirstName");
                    personInfo.LastName = this.MapToString(reader, "LastName");
                    personInfo.PersonType = this.MapToString(reader, "PersonType");
                    personInfo.Title = this.MapToString(reader, "Title");

                    results.Add(personInfo);
                }
            }

            return results;
        }

        public void Prepare()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
        }

        private string MapToString(SqlDataReader reader, string name)
        {
            object value = reader[name];
            if (value == DBNull.Value)
            {
                return null;
            }

            return (string)value;
        }

        private DateTime? MapToDateTime(SqlDataReader reader, string name)
        {
            object value = reader[name];
            if (value == DBNull.Value)
            {
                return null;
            }

            return (DateTime)value;
        }
    }
}
