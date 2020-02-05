using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Adapters
{
    public class DataReaderClsAdapter : IAdapter
    {
        private string connectionString;

        public string Name
        {
            get
            {
                return "Date Reader - closing";
            }
        }

        public DataReaderClsAdapter(Settings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            this.connectionString = settings.ConnectionString;
        }

        public void Relase()
        {

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

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

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
        }

        public List<PersonInfoDto> GetPagedPersons(int skip, int take)
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
  ORDER BY p.[ModifiedDate]
  OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                List<PersonInfoDto> results = new List<PersonInfoDto>(take);
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
        }

        public ShipMethodDto GetSimple(int id)
        {
            string sql = @"SELECT TOP 1 [ShipMethodID]
      ,[Name]
      ,[ShipBase]
      ,[ShipRate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2014].[Purchasing].[ShipMethod]
  WHERE [ShipMethodID] = @id";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@id", id);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ShipMethodDto personInfo = new ShipMethodDto();
                        personInfo.ShipMethodID = Convert.ToInt32(reader["ShipMethodID"]);
                        personInfo.ModifiedDate = this.MapToDateTime2(reader, "ModifiedDate");
                        personInfo.Name = this.MapToString(reader, "Name");
                        personInfo.ShipBase = Convert.ToDecimal(reader["ShipBase"]);
                        personInfo.ShipRate = Convert.ToDecimal(reader["ShipRate"]);
                        personInfo.rowguid = (Guid)reader["rowguid"];

                        return personInfo;
                    }
                }
            }

            throw new ArgumentException("Not found id");
        }

        public ProductDto GetProduct(int id)
        {

            string sql = @"SELECT
       [p].[ProductID]
      ,[p].[Name]
      ,[p].[ProductNumber]
      ,[p].[MakeFlag]
      ,[p].[FinishedGoodsFlag]
      ,[p].[Color]
      ,[p].[SafetyStockLevel]
      ,[p].[ReorderPoint]
      ,[p].[StandardCost]
      ,[p].[ListPrice]
      ,[p].[Size]
      ,[p].[SizeUnitMeasureCode]
      ,[p].[WeightUnitMeasureCode]
      ,[p].[Weight]
      ,[p].[DaysToManufacture]
      ,[p].[ProductLine]
      ,[p].[Class]
      ,[p].[Style]
      ,[p].[ProductSubcategoryID]
      ,[p].[ProductModelID]
      ,[p].[SellStartDate]
      ,[p].[SellEndDate]
      ,[p].[DiscontinuedDate]
      ,[p].[rowguid]
      ,[p].[ModifiedDate]
      ,[Plph].[EndDate]
      ,[Plph].[ListPrice]
      ,[Plph].[ModifiedDate]
      ,[Plph].[ProductID]
      ,[Plph].[StartDate]
  FROM [AdventureWorks2014].[Production].[Product] [p]
  LEFT JOIN [AdventureWorks2014].[Production].[ProductListPriceHistory] [Plph]
  ON [p].[ProductID] = [Plph].[ProductID]
  WHERE [p].[ProductID] = @Id;";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                bool isFirst = true;
                ProductDto productDto = new ProductDto();
                productDto.ProductListPriceHistories = new List<ProductListPriceHistoryDto>();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (isFirst)
                        {
                            productDto.ProductID = (int)reader["ProductID"];
                            productDto.Name = this.MapToString(reader, "Name");
                            productDto.ProductNumber = this.MapToString(reader, "ProductNumber");
                            productDto.MakeFlag = (bool)reader["MakeFlag"];
                            productDto.FinishedGoodsFlag = (bool)reader["FinishedGoodsFlag"];
                            productDto.Color = this.MapToString(reader, "Color");
                            productDto.SafetyStockLevel = (short)reader["SafetyStockLevel"];
                            productDto.ReorderPoint = (short)reader["ReorderPoint"];
                            productDto.StandardCost = (decimal)reader["StandardCost"];
                            productDto.ListPrice = (decimal)reader["ListPrice"];
                            productDto.Size = this.MapToString(reader, "Size");
                            productDto.SizeUnitMeasureCode = this.MapToString(reader, "SizeUnitMeasureCode");
                            productDto.WeightUnitMeasureCode = this.MapToString(reader, "WeightUnitMeasureCode");
                            productDto.Weight = this.MapToDecimal(reader, "Weight");
                            productDto.DaysToManufacture = (int)reader["DaysToManufacture"];
                            productDto.ProductLine = this.MapToString(reader, "ProductLine");
                            productDto.Class = this.MapToString(reader, "Class");
                            productDto.Style = this.MapToString(reader, "Style");
                            productDto.ProductSubcategoryID = this.MapToInt(reader, "ProductSubcategoryID");
                            productDto.ProductModelID = this.MapToInt(reader, "ProductModelID");
                            productDto.SellStartDate = (DateTime)reader["SellStartDate"];
                            productDto.SellEndDate = this.MapToDateTime(reader, "SellEndDate");
                            productDto.DiscontinuedDate = this.MapToDateTime(reader, "DiscontinuedDate");
                            productDto.rowguid = (Guid)reader["rowguid"];
                            productDto.ModifiedDate = (DateTime)reader["ModifiedDate"];

                            isFirst = false;
                        }

                        DateTime? stratDate = this.MapToDateTime(reader, "StartDate");
                        if (stratDate.HasValue)
                        {
                            ProductListPriceHistoryDto productListPriceHistoryDto = new ProductListPriceHistoryDto();
                            productListPriceHistoryDto.StartDate = stratDate.Value;
                            productListPriceHistoryDto.EndDate = this.MapToDateTime(reader, "EndDate");
                            productListPriceHistoryDto.ListPrice = (decimal)reader["ListPrice"];
                            productListPriceHistoryDto.ModifiedDate = (DateTime)reader["ModifiedDate"];
                            productListPriceHistoryDto.ProductID = (int)reader["ProductID"];

                            productDto.ProductListPriceHistories.Add(productListPriceHistoryDto);
                        }
                    }
                }

                if (isFirst)
                {
                    throw new ArgumentException("id");
                }

                return productDto;
            }
        }

        public Product2Dto GetProduct2(int id)
        {
            string sql = @"SELECT TOP 1
       [p].[ProductID]
      ,[p].[Name]
      ,[p].[ProductNumber]
      ,[p].[MakeFlag]
      ,[p].[FinishedGoodsFlag]
      ,[p].[Color]
      ,[p].[SafetyStockLevel]
      ,[p].[ReorderPoint]
      ,[p].[StandardCost]
      ,[p].[ListPrice]
      ,[p].[Size]
      ,[p].[SizeUnitMeasureCode]
      ,[p].[WeightUnitMeasureCode]
      ,[p].[Weight]
      ,[p].[DaysToManufacture]
      ,[p].[ProductLine]
      ,[p].[Class]
      ,[p].[Style]
      ,[p].[ProductSubcategoryID]
      ,[p].[ProductModelID]
      ,[p].[SellStartDate]
      ,[p].[SellEndDate]
      ,[p].[DiscontinuedDate]
      ,[p].[rowguid]
      ,[p].[ModifiedDate]
      ,[pm].[CatalogDescription]
	  ,[pm].[Instructions]
	  ,[pm].[ModifiedDate] AS [ProductModelNameModifiedDate]
	  ,[pm].[Name] AS [ProductModelName]
	  ,[pm].[rowguid] AS [ProductModelRowguid]
  FROM [AdventureWorks2014].[Production].[Product] [p]
  LEFT JOIN [AdventureWorks2014].[Production].[ProductModel] [pm]
  ON [p].[ProductModelID] = [pm].[ProductModelID]
  WHERE [p].[ProductID] = @Id;";
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                bool isFirst = true;
                Product2Dto productDto = new Product2Dto();

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (isFirst)
                        {
                            productDto.ProductID = (int)reader["ProductID"];
                            productDto.Name = this.MapToString(reader, "Name");
                            productDto.ProductNumber = this.MapToString(reader, "ProductNumber");
                            productDto.MakeFlag = (bool)reader["MakeFlag"];
                            productDto.FinishedGoodsFlag = (bool)reader["FinishedGoodsFlag"];
                            productDto.Color = this.MapToString(reader, "Color");
                            productDto.SafetyStockLevel = (short)reader["SafetyStockLevel"];
                            productDto.ReorderPoint = (short)reader["ReorderPoint"];
                            productDto.StandardCost = (decimal)reader["StandardCost"];
                            productDto.ListPrice = (decimal)reader["ListPrice"];
                            productDto.Size = this.MapToString(reader, "Size");
                            productDto.SizeUnitMeasureCode = this.MapToString(reader, "SizeUnitMeasureCode");
                            productDto.WeightUnitMeasureCode = this.MapToString(reader, "WeightUnitMeasureCode");
                            productDto.Weight = this.MapToDecimal(reader, "Weight");
                            productDto.DaysToManufacture = (int)reader["DaysToManufacture"];
                            productDto.ProductLine = this.MapToString(reader, "ProductLine");
                            productDto.Class = this.MapToString(reader, "Class");
                            productDto.Style = this.MapToString(reader, "Style");
                            productDto.ProductSubcategoryID = this.MapToInt(reader, "ProductSubcategoryID");
                            productDto.ProductModelID = this.MapToInt(reader, "ProductModelID");
                            productDto.SellStartDate = (DateTime)reader["SellStartDate"];
                            productDto.SellEndDate = this.MapToDateTime(reader, "SellEndDate");
                            productDto.DiscontinuedDate = this.MapToDateTime(reader, "DiscontinuedDate");
                            productDto.rowguid = (Guid)reader["rowguid"];
                            productDto.ModifiedDate = (DateTime)reader["ModifiedDate"];

                            isFirst = false;
                        }

                        if (productDto.ProductModelID.HasValue)
                        {
                            productDto.ProductModel = new ProductModelDto();
                            productDto.ProductModel.ProductModelID = productDto.ProductModelID.Value;
                            productDto.ProductModel.CatalogDescription = this.MapToString(reader, "CatalogDescription");
                            productDto.ProductModel.Instructions = this.MapToString(reader, "Instructions");
                            productDto.ProductModel.ModifiedDate = (DateTime)reader["ProductModelNameModifiedDate"];
                            productDto.ProductModel.Name = this.MapToString(reader, "ProductModelName");
                            productDto.ProductModel.rowguid = (Guid)reader["ProductModelRowguid"];
                        }
                    }
                }

                if (isFirst)
                {
                    throw new ArgumentException("id");
                }

                return productDto;
            }
        }

        public void Prepare()
        {

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

        private int? MapToInt(SqlDataReader reader, string name)
        {
            object value = reader[name];
            if (value == DBNull.Value)
            {
                return null;
            }

            return (int?)value;
        }

        private decimal? MapToDecimal(SqlDataReader reader, string name)
        {
            object value = reader[name];
            if (value == DBNull.Value)
            {
                return null;
            }

            return (decimal?)value;
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

        private DateTime MapToDateTime2(SqlDataReader reader, string name)
        {
            object value = reader[name];
            if (value == DBNull.Value)
            {
                throw new ArgumentException(name);
            }

            return (DateTime)value;
        }
    }
}
