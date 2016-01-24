﻿using MapperPerformace.Ef;
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
            Mapper.CreateMap<Person, PersonInfoDto>();
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

        public void Prepare()
        {
            this.dbContext = new AdventureWorks2014Entities();
        }
    }
}