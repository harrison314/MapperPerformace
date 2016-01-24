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

            container.GetInstance<Tester>().TestGetAllPersons(2);

            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            container.GetInstance<Tester>().TestGetAllPersons(20);
            container.GetInstance<Tester>().TestGetAllPersons(20);
            container.GetInstance<Tester>().TestGetAllPersons(20);

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
            container.Register<Tester>(Lifestyle.Transient);

            container.Verify();

            return container;
        }
    }
}
