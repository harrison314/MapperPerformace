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

        public ShipMethodDto GetSimple(int id)
        {
            ShipMethod shipMethodEf = this.dbContext.ShipMethods.Find(id);
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

        public ProductDto GetProduct(int id)
        {
            Product product = this.dbContext.Products.Find(id);
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

        public void Prepare()
        {
            this.dbContext = new AdventureWorks2014Entities();
        }
    }
}
