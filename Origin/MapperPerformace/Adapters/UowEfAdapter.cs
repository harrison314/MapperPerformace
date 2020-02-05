using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapperPerformace.Ef;

namespace MapperPerformace.Adapters
{
    public class UowEfAdapter : IAdapter
    {


        public string Name
        {
            get
            {
                return "Entity Framework - UoF";
            }
        }

        public UowEfAdapter()
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

        public List<PersonInfoDto> GetPagedPersons(int skip, int take)
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

        public ShipMethodDto GetSimple(int id)
        {
            using (AdventureWorks2014Entities dbContext = new AdventureWorks2014Entities())
            {
                ShipMethod shipMethodEf = dbContext.ShipMethods.Find(id);
                if (shipMethodEf == null)
                {
                    throw new ArgumentException("Not found id");
                }

                ShipMethodDto shipMethodDto = new ShipMethodDto();
                shipMethodDto.ModifiedDate = shipMethodEf.ModifiedDate;
                shipMethodDto.Name = shipMethodEf.Name;
                shipMethodDto.rowguid = shipMethodEf.rowguid;
                shipMethodDto.ShipBase = shipMethodEf.ShipBase;
                shipMethodDto.ShipMethodID = shipMethodEf.ShipMethodID;
                shipMethodDto.ShipRate = shipMethodEf.ShipRate;

                return shipMethodDto;
            }
        }

        public ProductDto GetProduct(int id)
        {
            using (AdventureWorks2014Entities dbContext = new AdventureWorks2014Entities())
            {
                Product product = dbContext.Products.Find(id);
                if (product == null)
                {
                    throw new ArgumentException("id");
                }

                ProductDto productDto = new ProductDto();
                productDto.ProductID = product.ProductID;
                productDto.Name = product.Name;
                productDto.ProductNumber = product.ProductNumber;
                productDto.MakeFlag = product.MakeFlag;
                productDto.FinishedGoodsFlag = product.FinishedGoodsFlag;
                productDto.Color = product.Color;
                productDto.SafetyStockLevel = product.SafetyStockLevel;
                productDto.ReorderPoint = product.ReorderPoint;
                productDto.StandardCost = product.StandardCost;
                productDto.ListPrice = product.ListPrice;
                productDto.Size = product.Size;
                productDto.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                productDto.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                productDto.Weight = product.Weight;
                productDto.DaysToManufacture = product.DaysToManufacture;
                productDto.ProductLine = product.ProductLine;
                productDto.Class = product.Class;
                productDto.Style = product.Style;
                productDto.ProductSubcategoryID = product.ProductSubcategoryID;
                productDto.ProductModelID = product.ProductModelID;
                productDto.SellStartDate = product.SellStartDate;
                productDto.SellEndDate = product.SellEndDate;
                productDto.DiscontinuedDate = product.DiscontinuedDate;
                productDto.rowguid = product.rowguid;
                productDto.ModifiedDate = product.ModifiedDate;

                productDto.ProductListPriceHistories = new List<ProductListPriceHistoryDto>();
                foreach (ProductListPriceHistory productListPriceHistory in product.ProductListPriceHistories)
                {
                    ProductListPriceHistoryDto productListPriceHistoryDto = new ProductListPriceHistoryDto();
                    productListPriceHistoryDto.EndDate = productListPriceHistory.EndDate;
                    productListPriceHistoryDto.ListPrice = productListPriceHistory.ListPrice;
                    productListPriceHistoryDto.ModifiedDate = productListPriceHistory.ModifiedDate;
                    productListPriceHistoryDto.ProductID = productListPriceHistory.ProductID;
                    productListPriceHistoryDto.StartDate = productListPriceHistory.StartDate;

                    productDto.ProductListPriceHistories.Add(productListPriceHistoryDto);
                }

                return productDto;
            }
        }

        public Product2Dto GetProduct2(int id)
        {
            using (AdventureWorks2014Entities dbContext = new AdventureWorks2014Entities())
            {
                Product product = dbContext.Products.Find(id);
                if (product == null)
                {
                    throw new ArgumentException("id");
                }

                Product2Dto productDto = new Product2Dto();
                productDto.ProductID = product.ProductID;
                productDto.Name = product.Name;
                productDto.ProductNumber = product.ProductNumber;
                productDto.MakeFlag = product.MakeFlag;
                productDto.FinishedGoodsFlag = product.FinishedGoodsFlag;
                productDto.Color = product.Color;
                productDto.SafetyStockLevel = product.SafetyStockLevel;
                productDto.ReorderPoint = product.ReorderPoint;
                productDto.StandardCost = product.StandardCost;
                productDto.ListPrice = product.ListPrice;
                productDto.Size = product.Size;
                productDto.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                productDto.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                productDto.Weight = product.Weight;
                productDto.DaysToManufacture = product.DaysToManufacture;
                productDto.ProductLine = product.ProductLine;
                productDto.Class = product.Class;
                productDto.Style = product.Style;
                productDto.ProductSubcategoryID = product.ProductSubcategoryID;
                productDto.ProductModelID = product.ProductModelID;
                productDto.SellStartDate = product.SellStartDate;
                productDto.SellEndDate = product.SellEndDate;
                productDto.DiscontinuedDate = product.DiscontinuedDate;
                productDto.rowguid = product.rowguid;
                productDto.ModifiedDate = product.ModifiedDate;

                if (product.ProductModel != null)
                {
                    productDto.ProductModel = new ProductModelDto();
                    productDto.ProductModel.CatalogDescription = product.ProductModel.CatalogDescription;
                    productDto.ProductModel.Instructions = product.ProductModel.Instructions;
                    productDto.ProductModel.ModifiedDate = product.ProductModel.ModifiedDate;
                    productDto.ProductModel.Name = product.ProductModel.Name;
                    productDto.ProductModel.ProductModelID = product.ProductModel.ProductModelID;
                    productDto.ProductModel.rowguid = product.ProductModel.rowguid;
                }

                return productDto;
            }
        }

        public void Prepare()
        {

        }
    }
}
