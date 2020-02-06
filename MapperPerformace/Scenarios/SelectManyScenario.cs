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
    public class SelectManyScenario : IScenario
    {
        private readonly string connectionString;
        private int minLocalId;
        private int count;
        private int offset;

        public SelectManyScenario(string connectionString, int pageSize = 150, int offset = 4)
        {
            this.connectionString = connectionString;
            this.minLocalId = 51;
            this.count = pageSize;
            this.offset = offset;
        }

        public async ValueTask<object> Dapper()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            IEnumerable<LocalEvent> result = await connection.QueryAsync<LocalEvent>(@"SELECT [LocalEventID]
      ,[Id]
      ,[PersonalID]
      ,[Street]
      ,[City]
      ,[Complexity]
      ,[Description]
      ,[HData]
  FROM [MapperPerformace].[dbo].[LocalEvent]
  WHERE [LocalEventID] >= @minLocalEventId
  ORDER BY [Id] ASC
  OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY",
                new
                {
                    minLocalEventId = this.minLocalId,
                    offset = this.offset,
                    pageSize = this.count
                });

            return result.ToList();
        }

        public async ValueTask<object> EfCore()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            List<LocalEvent> result = await context.LocalEvent
                .Where(t => t.LocalEventId >= this.minLocalId)
                .Skip(this.offset)
                .Take(this.count)
                .ToListAsync();

            return result;
        }

        public async ValueTask<object> EfCoreAsNoTracking()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            List<LocalEvent> result = await context.LocalEvent
                .AsNoTracking()
                .Where(t => t.LocalEventId >= this.minLocalId)
                .Skip(this.offset)
                .Take(this.count)
                .ToListAsync();

            return result;
        }

        public async ValueTask<object> SqlClient()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT [LocalEventID]
      ,[Id]
      ,[PersonalID]
      ,[Street]
      ,[City]
      ,[Complexity]
      ,[Description]
      ,[HData]
  FROM [MapperPerformace].[dbo].[LocalEvent]
  WHERE [LocalEventID] >= @minLocalEventId
  ORDER BY [Id] ASC
  OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";
            command.Parameters.AddWithValue("@minLocalEventId", this.minLocalId);
            command.Parameters.AddWithValue("@offset", this.offset);
            command.Parameters.AddWithValue("@pageSize", this.count);

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            List<LocalEvent> result = new List<LocalEvent>(this.count + 2);
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