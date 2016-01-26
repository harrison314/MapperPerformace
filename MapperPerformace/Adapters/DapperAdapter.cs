using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace MapperPerformace.Adapters
{
    public class DapperAdapter : IAdapter
    {
        private string connectionString;
        private SqlConnection connection;

        public string Name
        {
            get
            {
                return "Dapper";
            }
        }

        public DapperAdapter(Settings settings)
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

            IEnumerable<PersonInfoDto> projection = this.connection.Query<PersonInfoDto>(sql);
            return projection.ToList();
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


            IEnumerable<PersonInfoDto> projection = this.connection.Query<PersonInfoDto>(sql,
                new { Skip = skip, Take = take });
            return projection.ToList();

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
  WHERE [ShipMethodID] = @Id";

            ShipMethodDto dto = this.connection.Query<ShipMethodDto>(sql, new { Id = id }).FirstOrDefault();
            if (dto == null)
            {
                throw new ArgumentException("Not found id");
            }

            return dto;
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

            Dictionary<int, ProductDto> cache = new Dictionary<int, ProductDto>();

            ProductDto dto = this.connection.Query<ProductDto, ProductListPriceHistoryDto, ProductDto>(sql,
                map:(p, Plph) =>
                {
                    

                    if (Plph != null)
                    {
                        ProductDto left;
                        if (cache.TryGetValue(p.ProductID, out left))
                        {
                            p = left;
                        }
                        else
                        {
                            cache[p.ProductID] = p;
                        }

                        p.ProductListPriceHistories.Add(Plph);
                    }
                    //p.ProductListPriceHistories = Plph;
                    return p;
                },
                param: new { Id = id }, 
                splitOn: "ProductID").FirstOrDefault();

            if (dto == null)
            {
                throw new ArgumentException("id");
            }
 
            return dto;
        }

        public void Prepare()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
        }
    }
}