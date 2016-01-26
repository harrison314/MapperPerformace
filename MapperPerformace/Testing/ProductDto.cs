using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    [System.Diagnostics.DebuggerDisplay("Id: {ProductID}, Count: {ProductListPriceHistories.Count}")]
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public Nullable<int> ProductSubcategoryID { get; set; }
        public Nullable<int> ProductModelID { get; set; }
        public System.DateTime SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public List<ProductListPriceHistoryDto> ProductListPriceHistories
        {
            get;
            set;
        }

        public ProductDto()
        {
            this.ProductListPriceHistories = new List<ProductListPriceHistoryDto>();
        }
    }


    public class ProductListPriceHistoryDto
    {
        public int ProductID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public ProductListPriceHistoryDto()
        {

        }

    }
}
