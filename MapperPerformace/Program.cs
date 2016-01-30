using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using MapperPerformace.Testing;
using System.Configuration;

namespace MapperPerformace
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = Bootstrap();

            container.GetInstance<PerformaceTester>().TestLoadLargeTable(2);
            container.GetInstance<PerformaceTester>().TestLoadPagerRecords(2);
            container.GetInstance<PerformaceTester>().TestLoadOneSimpleRow(2);
            container.GetInstance<PerformaceTester>().TestLoadRowWithJoinedCollection(2);


            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            /*
            container.GetInstance<PerformaceTester>().TestLoadLargeTable(20);
            container.GetInstance<PerformaceTester>().TestLoadLargeTable(20);
            container.GetInstance<PerformaceTester>().TestLoadLargeTable(20);
            
            container.GetInstance<PerformaceTester>().TestLoadPagerRecords(40);
            container.GetInstance<PerformaceTester>().TestLoadPagerRecords(40);
            container.GetInstance<PerformaceTester>().TestLoadPagerRecords(40);
            container.GetInstance<PerformaceTester>().TestLoadPagerRecords(40);
            

            container.GetInstance<PerformaceTester>().TestLoadOneSimpleRow(40);

            container.GetInstance<PerformaceTester>().TestLoadRowWithJoinedCollection(150);
            container.GetInstance<PerformaceTester>().TestLoadRowWithJoinedEntity(200);
            */

            container.GetInstance<PerformaceTester>().TestCombined(500);

            container.Dispose();
            Console.WriteLine();
            Console.WriteLine("Done ...");
            Console.ReadLine();
        }

        static Container Bootstrap()
        {
            Container container = new Container();
            container.RegisterCollection(typeof(IAdapter), new[] { typeof(IAdapter).Assembly });
            Settings settings = new Settings();
            settings.ConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2014"].ConnectionString;

            container.RegisterSingleton<Settings>(settings);
            container.Register<PerformaceTester>(Lifestyle.Transient);

            container.Verify();
            AutoMapper.Mapper.AssertConfigurationIsValid();

            return container;
        }
    }
}
