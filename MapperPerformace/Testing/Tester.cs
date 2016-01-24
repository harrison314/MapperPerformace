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
            foreach (IAdapter adapter in this.adapters)
            {
                GC.Collect();
                this.TestGetAllPersons(adapter, count);
            }

            Console.WriteLine();
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
                Math.Round( 1000.0 * stp.Elapsed.TotalMilliseconds / mcount, 4));

            adapter.Relase();
        }
    }
}
