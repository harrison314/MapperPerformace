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
    public class SelectOneRowScenario : IScenario
    {
        private readonly string connectionString;
        private int id;

        public SelectOneRowScenario(string connectionString)
        {
            this.connectionString = connectionString;
            this.id = 1051;
        }

        public async ValueTask<object> Dapper()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            LocalEvent result = await connection.QueryFirstAsync<LocalEvent>("SELECT TOP (1) [Id], [LocalEventId], [PersonalID], [Street], [City], [Complexity], [Description], [HData] FROM [dbo].[LocalEvent] WHERE [Id] = @id",
                new { id = this.id });

            return result;
        }

        public async ValueTask<object> EfCore()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            LocalEvent result = await context.LocalEvent.FindAsync(this.id);

            return result;
        }

        public async ValueTask<object> EfCoreAsNoTracking()
        {
            using MapperPerformaceContext context = new MapperPerformaceContext();
            LocalEvent result = await context.LocalEvent.AsNoTracking().Where(t => t.Id == this.id).FirstAsync();

            return result;
        }

        public async ValueTask<object> SqlClient()
        {
            using SqlConnection connection = new SqlConnection(this.connectionString);
            await connection.OpenAsync();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT TOP (1) [Id], [LocalEventId], [PersonalID], [Street], [City], [Complexity], [Description], [HData] FROM [dbo].[LocalEvent] WHERE [Id] = @id";
            command.Parameters.AddWithValue("@id", this.id);

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
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

                return le;
            }
            else
            {
                return null;
            }
        }
    }
}
