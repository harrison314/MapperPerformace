using MapperPerformace.Ef;
using MapperPerformace.Testing;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Adapters
{
    public class ValueInjecterAdapter : IAdapter
    {
        private MapperInstance mapper;
        private AdventureWorks2014Entities dbContext;

        public string Name
        {
            get
            {
                return "Value Injecter";
            }
        }

        public ValueInjecterAdapter()
        {
            this.mapper = new MapperInstance();
            this.MapperConfigure(this.mapper);
            this.dbContext = null;
        }

        public void Prepare()
        {
            this.dbContext = new AdventureWorks2014Entities();
        }

        public void Relase()
        {
            this.dbContext?.Dispose();
            this.dbContext = null;
        }

        public List<PersonInfoDto> GetAllPersons()
        {
            IQueryable<Person> projection = this.dbContext.People.OrderBy(t => t.ModifiedDate);

            List<PersonInfoDto> rezult = new List<PersonInfoDto>();
            foreach (Person person in projection)
            {
                rezult.Add(this.mapper.Map<PersonInfoDto>(person));
            }

            return rezult;
        }

        public List<PersonInfoDto> GetPagedPersons(int skip, int take)
        {
            IEnumerable<Person> projection =
                this.dbContext.People.OrderBy(t => t.ModifiedDate)
                .Skip(skip).Take(take);

            List<PersonInfoDto> rezult = new List<PersonInfoDto>();
            foreach (Person person in projection)
            {
                rezult.Add(this.mapper.Map<PersonInfoDto>(person));
            }

            return rezult;
        }

        public ProductDto GetProduct(int id)
        {
            Product product = this.dbContext.Products.Find(id);
            if (product == null)
            {
                throw new ArgumentException("id");
            }

            ProductDto productDto = this.mapper.Map<ProductDto>(product);

            return productDto;
        }

        public Product2Dto GetProduct2(int id)
        {
            Product product = this.dbContext.Products.Find(id);
            if (product == null)
            {
                throw new ArgumentException("id");
            }
            Product2Dto productDto = this.mapper.Map<Product2Dto>(product);

            return productDto;
        }

        public ShipMethodDto GetSimple(int id)
        {
            ShipMethod shipMethodEf = this.dbContext.ShipMethods.Find(id);
            if (shipMethodEf == null)
            {
                throw new ArgumentException("Not found id");
            }

            ShipMethodDto shipMethodDto = this.mapper.Map<ShipMethodDto>(shipMethodEf);

            return shipMethodDto;
        }

        private void MapperConfigure(MapperInstance cfd)
        {
            cfd.AddMap<Person, PersonInfoDto>(src =>
            {
                PersonInfoDto dst = new PersonInfoDto();
                dst.InjectFrom(src);
                dst.EmployeeBrithDate = src.Employee?.BirthDate;

                return dst;
            });

            cfd.AddMap<EmailAddress, EmailDto>(src =>
            {
                EmailDto dst = new EmailDto();
                dst.InjectFrom(src);
                dst.EmailAddress = src.EmailAddress1;

                return dst;
            });

            cfd.AddMap<ShipMethod, ShipMethodDto>(src =>
            {
                ShipMethodDto dst = new ShipMethodDto();
                dst.InjectFrom(src);
                return dst;
            });

            cfd.AddMap<ProductListPriceHistory, ProductListPriceHistoryDto>(src =>
            {
                ProductListPriceHistoryDto dst = new ProductListPriceHistoryDto();
                dst.InjectFrom(src);
                return dst;
            });

            cfd.AddMap<Product, ProductDto>(src =>
            {
                ProductDto dst = new ProductDto();
                dst.InjectFrom(src);
                dst.ProductListPriceHistories = new List<ProductListPriceHistoryDto>();
                foreach (ProductListPriceHistory item in src.ProductListPriceHistories)
                {
                    ProductListPriceHistoryDto itemDto = new ProductListPriceHistoryDto();
                    itemDto.InjectFrom(item);

                    dst.ProductListPriceHistories.Add(itemDto);
                }

                return dst;
            });

            cfd.AddMap<ProductModel, ProductModelDto>(src =>
            {
                ProductModelDto dst = new ProductModelDto();
                dst.InjectFrom(src);
                return dst;
            });

            cfd.AddMap<Product, Product2Dto>(src =>
            {
                Product2Dto dst = new Product2Dto();
                dst.InjectFrom(src);
                dst.ProductModel = new ProductModelDto();
                dst.ProductModel.InjectFrom(src.ProductModel);
                dst.ProductModelID = src.ProductModel?.ProductModelID;

                return dst;
            });
        }
    }
}
