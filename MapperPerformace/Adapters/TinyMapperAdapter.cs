using MapperPerformace.Ef;
using MapperPerformace.Testing;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Adapters
{
    public class TinyMapperAdapter : IAdapter
    {
        private AdventureWorks2014Entities dbContext;

        public string Name
        {
            get
            {
                return "Tiny Mapper";
            }
        }

        static TinyMapperAdapter()
        {
            TinyMapper.Bind<Person, PersonInfoDto>();
            TinyMapper.Bind<EmailAddress, EmailDto>();
            TinyMapper.Bind<ShipMethod, ShipMethodDto>();
            TinyMapper.Bind<ProductListPriceHistory, ProductListPriceHistoryDto>();
            TinyMapper.Bind<Product, ProductDto>();
            TinyMapper.Bind<ProductModel, ProductModelDto>();
            TinyMapper.Bind<Product, Product2Dto>();
        }

        public TinyMapperAdapter()
        {
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
                rezult.Add(TinyMapper.Map<PersonInfoDto>(person));
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
                rezult.Add(TinyMapper.Map<PersonInfoDto>(person));
            }

            return rezult;
        }

        public ShipMethodDto GetSimple(int id)
        {
            ShipMethod shipMethodEf = this.dbContext.ShipMethods.Find(id);
            if (shipMethodEf == null)
            {
                throw new ArgumentException("Not found id");
            }

            ShipMethodDto shipMethodDto = TinyMapper.Map<ShipMethodDto>(shipMethodEf);

            return shipMethodDto;
        }

        public ProductDto GetProduct(int id)
        {
            Product product = this.dbContext.Products.Find(id);
            if (product == null)
            {
                throw new ArgumentException("id");
            }

            ProductDto productDto = TinyMapper.Map<ProductDto>(product);

            return productDto;
        }


        public Product2Dto GetProduct2(int id)
        {
            Product product = this.dbContext.Products.Find(id);
            if (product == null)
            {
                throw new ArgumentException("id");
            }
            Product2Dto productDto = TinyMapper.Map<Product2Dto>(product);

            return productDto;
        }
    }
}
