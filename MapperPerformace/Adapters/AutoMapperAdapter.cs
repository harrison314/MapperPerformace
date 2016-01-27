using MapperPerformace.Ef;
using MapperPerformace.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MapperPerformace.Adapters
{
    public class AutoMapperAdapter : IAdapter
    {
        private AdventureWorks2014Entities dbContext;

        public string Name
        {
            get
            {
                return "Entity Framework - AutoMapper";
            }
        }

        static AutoMapperAdapter()
        {
            Mapper.CreateMap<Person, PersonInfoDto>(MemberList.Destination)
                .ForMember(t => t.EmployeeBrithDate, t => t.MapFrom(src => src.Employee.BirthDate));
            Mapper.CreateMap<EmailAddress, EmailDto>(MemberList.Destination)
                .ForMember(t => t.EmailAddress, t => t.MapFrom(src => src.EmailAddress1));
            Mapper.CreateMap<ShipMethod, ShipMethodDto>(MemberList.Destination);
            Mapper.CreateMap<ProductListPriceHistory, ProductListPriceHistoryDto>(MemberList.Destination);
            Mapper.CreateMap<Product, ProductDto>(MemberList.Destination);
            Mapper.CreateMap<ProductModel, ProductModelDto>(MemberList.Destination);
            Mapper.CreateMap<Product, Product2Dto>(MemberList.Destination);
        }

        public AutoMapperAdapter()
        {
            this.dbContext = null;
        }

        public void Relase()
        {
            this.dbContext?.Dispose();
        }

        public List<PersonInfoDto> GetAllPersons()
        {
            List<PersonInfoDto> rezult = this.dbContext.People.OrderBy(t => t.ModifiedDate)
                .ProjectToList<PersonInfoDto>();

            return rezult;
        }

        public List<PersonInfoDto> GetPagedPersons(int skip, int take)
        {
            List<PersonInfoDto> rezult = this.dbContext.People.OrderBy(t => t.ModifiedDate)
                .Skip(skip).Take(take)
                .ProjectToList<PersonInfoDto>();

            return rezult;
        }

        public ShipMethodDto GetSimple(int id)
        {
            ShipMethod shipMethodEf = this.dbContext.ShipMethods.Find(id);
            if (shipMethodEf == null)
            {
                throw new ArgumentException("Not found id");
            }

            ShipMethodDto shipMethodDto = Mapper.Map<ShipMethod, ShipMethodDto>(shipMethodEf);

            return shipMethodDto;
        }

        public ProductDto GetProduct(int i)
        {
            ProductDto rezult = this.dbContext.Products.Where(t => t.ProductID == i).ProjectToFirst<ProductDto>();
            return rezult;
        }

        public Product2Dto GetProduct2(int id)
        {
            Product2Dto product = dbContext.Products.Where(t => t.ProductID == id).ProjectToFirst<Product2Dto>();
            if (product == null)
            {
                throw new ArgumentException("id");
            }

            return product;
        }

        public void Prepare()
        {
            this.dbContext = new AdventureWorks2014Entities();
        }
    }
}
