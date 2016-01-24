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

            this.adapters = adapters.OrderBy(t=>t.Name);
        }

        public void TestGetAllPersons(int count = 10)
        {
            foreach(IAdapter adapter in this.adapters)
            {
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
            for(int i=0; i< count; i++)
            {
                List<PersonInfoDto> infos = adapter.GetAllPersons();
                mcount += infos.Count;
            }
            stp.Stop();
            Console.WriteLine("{0,-30} - {1,6} ms ({2})", adapter.Name, stp.ElapsedMilliseconds, mcount);

            adapter.Relase();
        }
    }
}
