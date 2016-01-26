﻿using MapperPerformace.Testing;
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

        public List<PersonInfoDto> GetPaggedPersons(int skip, int take)
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

            SqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@Skip", skip);
            cmd.Parameters.AddWithValue("@Take", take);

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

            SqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@id", id);

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

            SqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@Id", id);

            bool isFirst = true;
            ProductDto productDto = new ProductDto();
            productDto.ProductListPriceHistories = new List<ProductListPriceHistoryDto>();

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


    /// <summary>
    /// Sql Data Reader Helper
    /// </summary>
    /// <remarks>
    /// From https://github.com/StackExchange/dapper-dot-net/blob/4f3a04cfaabfa3a6e1cd64e23fbbcbaf63d74a8c/Dapper.Tests/PerformanceTests.cs
    /// </remarks>
    static class SqlDataReaderHelper
    {
        public static string GetNullableString(this SqlDataReader reader, int index)
        {
            object tmp = reader.GetValue(index);
            if (tmp != DBNull.Value)
            {
                return (string)tmp;
            }
            return null;
        }

        public static Nullable<T> GetNullableValue<T>(this SqlDataReader reader, int index) where T : struct
        {
            object tmp = reader.GetValue(index);
            if (tmp != DBNull.Value)
            {
                return (T)tmp;
            }

            return null;
        }

        public static Nullable<T> GetNullableValue<T>(this SqlDataReader reader, string name) where T : struct
        {
            object tmp = reader[name];
            if (tmp != DBNull.Value)
            {
                return (T)tmp;
            }

            return null;
        }
    }
}
