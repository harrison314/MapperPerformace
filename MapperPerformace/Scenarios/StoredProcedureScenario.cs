using Dapper;
using MapperPerformace.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Scenarios
{
    public class StoredProcedureScenario : IScenario
    {
        private readonly string connectionString;
        private int minComplexity = 25;
        private int maxComplexity = 50;
        public StoredProcedureScenario(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async ValueTask<object> Dapper()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            IEnumerable<LocalEvent> result = await connection.QueryAsync<LocalEvent>(@"[dbo].[GetLocalEvents]",
                new
                {
                    minComplexity = this.minComplexity,
                    maxComplexity = this.maxComplexity
                }, commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }

        public async ValueTask<object> EfCore()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            List<LocalEvent> result = await context.LocalEvent.FromSqlRaw($"[dbo].[GetLocalEvents] {this.minComplexity}, {this.maxComplexity}")
                .ToListAsync();

            return result;
        }

        public async ValueTask<object> EfCoreAsNoTracking()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            List<LocalEvent> result = await context.LocalEvent.FromSqlRaw($"[dbo].[GetLocalEvents] {this.minComplexity}, {this.maxComplexity}")
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async ValueTask<object> SqlClient()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"[dbo].[GetLocalEvents]";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@minComplexity", this.minComplexity);
            command.Parameters.AddWithValue("@maxComplexity", this.maxComplexity);

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            List<LocalEvent> result = new List<LocalEvent>();
            while (await reader.ReadAsync())
            {
                LocalEvent le = new LocalEvent();
                le.Id = Convert.ToInt32(reader["Id"]);
                le.LocalEventId = Convert.ToInt32(reader["LocalEventId"]);
                le.PersonalId = Convert.ToString(reader["PersonalID"]);
                le.Street = Convert.ToString(reader["Street"]);
                le.City = Convert.ToString(reader["City"]);
                le.Complexity = Convert.ToInt32(reader["Complexity"]);
                le.Description = Convert.ToString(reader["Description"]);
                le.Hdata = (Guid)reader["HData"];

                result.Add(le);
            }

            return result;
        }
    }
}
