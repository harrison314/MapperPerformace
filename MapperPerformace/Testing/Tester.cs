using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    public class Tester
    {
        private readonly IEnumerable<IAdapter> adapters;

        public Tester(IEnumerable<IAdapter> adapters)
        {
            if (adapters == null) throw new ArgumentNullException(nameof(adapters));

            this.adapters = adapters.OrderBy(t => t.Name);
        }

        public void TestGetAllPersons(int count = 10)
        {
            Console.WriteLine("GetAllPersons");
            foreach (IAdapter adapter in this.adapters)
            {
                GC.Collect();
                this.TestGetAllPersons(adapter, count);
            }

            Console.WriteLine();
        }

        public void TestGetPaggedPersons(int count = 10)
        {
            Console.WriteLine("GetAllPersons");
            foreach (IAdapter adapter in this.adapters)
            {
                GC.Collect();
                this.TestGetPaggedPersons(adapter, count);
            }

            Console.WriteLine();
        }

        public void TestGetSimple(int count = 10)
        {
            Console.WriteLine("GetSimple");
            foreach (IAdapter adapter in this.adapters)
            {
                GC.Collect();
                this.TestGetSimple(adapter, count);
            }

            Console.WriteLine();
        }

        public void TestGetSimple(IAdapter adapter, int count)
        {
            adapter.Prepare();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < count; i++)
            {
                ShipMethodDto dto5 = adapter.GetSimple(5);
                ShipMethodDto dto3 = adapter.GetSimple(3);
                ShipMethodDto dto1 = adapter.GetSimple(1);
                ShipMethodDto dto2 = adapter.GetSimple(2);
                ShipMethodDto dto4 = adapter.GetSimple(4);
            }
            stp.Stop();

            Console.WriteLine("{0,-30} - {1,6} ms {2,6} us",
                adapter.Name,
                stp.ElapsedMilliseconds,
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / 5, 4));

            adapter.Relase();
        }

        private void TestGetAllPersons(IAdapter adapter, int count)
        {
            long mcount = 0L;
            adapter.Prepare();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < count; i++)
            {
                List<PersonInfoDto> infos = adapter.GetAllPersons();
                mcount += infos.Count;
            }
            stp.Stop();

            Console.WriteLine("{0,-30} - {1,6} ms ({2}) {3,6} us",
                adapter.Name,
                stp.ElapsedMilliseconds,
                mcount,
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / mcount, 4));

            adapter.Relase();
        }


        private void TestGetPaggedPersons(IAdapter adapter, int count)
        {
            long mcount = 0L;
            adapter.Prepare();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < count; i++)
            {
                List<PersonInfoDto> infos = adapter.GetPaggedPersons((count * 10) % 10000, 5);
                mcount += infos.Count;
            }
            stp.Stop();

            Console.WriteLine("{0,-30} - {1,6} ms ({2}) {3,6} us",
                adapter.Name,
                stp.ElapsedMilliseconds,
                mcount,
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / mcount, 4));

            adapter.Relase();
        }
    }
}
