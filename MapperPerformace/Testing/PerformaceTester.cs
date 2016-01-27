using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace.Testing
{
    /// <summary>
    /// Performace tester.
    /// </summary>
    public class PerformaceTester
    {
        private readonly IEnumerable<IAdapter> adapters;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformaceTester"/> class.
        /// </summary>
        /// <param name="adapters">The collection of adapters.</param>
        /// <exception cref="ArgumentNullException">adapters</exception>
        public PerformaceTester(IEnumerable<IAdapter> adapters)
        {
            if (adapters == null) throw new ArgumentNullException(nameof(adapters));

            this.adapters = adapters.OrderBy(t => t.Name);
        }

        /// <summary>
        /// Tests performace of load large table with mapping to DTO object.
        /// </summary>
        /// <param name="count">The count.</param>
        public void TestLoadLargeTable(int count = 10)
        {
            Console.WriteLine("Tests - load large table");
            foreach (IAdapter adapter in this.adapters)
            {
                GC.Collect();
                this.TestGetAllPersons(adapter, count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Tests performace of mapping pagged results.
        /// </summary>
        /// <param name="count">The count.</param>
        public void TestLoadPagerRecords(int count = 10)
        {
            Console.WriteLine("Test - pagged result");
            foreach (IAdapter adapter in this.adapters)
            {
                this.TestGetPaggedPersons(adapter, count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Tests the load one simple row by Id and mapping.
        /// </summary>
        /// <param name="count">The count.</param>
        public void TestLoadOneSimpleRow(int count = 10)
        {
            Console.WriteLine("Test - load one row");
            foreach (IAdapter adapter in this.adapters)
            {
                this.TestGetSimple(adapter, count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Tests performace of load row with joined collection, and mapping.
        /// </summary>
        /// <param name="count">The count.</param>
        public void TestLoadRowWithJoinedCollection(int count = 10)
        {
            Console.WriteLine("Test - Load row with joined collection");
            foreach (IAdapter adapter in this.adapters)
            {
                this.TestGetProduct(adapter, count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Tests performace of load row with joined entity and mapping.
        /// </summary>
        /// <param name="count">The count.</param>
        public void TestLoadRowWithJoinedEntity(int count = 10)
        {
            Console.WriteLine("Test- load row with joined entity");
            foreach (IAdapter adapter in this.adapters)
            {
                this.TestGetProduct2(adapter, count);
            }

            Console.WriteLine();
        }

        private void TestGetProduct2(IAdapter adapter, int count)
        {
            int[] ids = new int[]
            {
                752, 928, 756, 858, 711, 788, 743, 990, 948, 769, 979, 906, 833,
                741, 790, 776, 919, 822, 819, 976, 718, 913, 887, 751, 911, 739,
                765, 836, 873, 967,
            };

            adapter.Prepare();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < count; i++)
            {
                adapter.GetProduct2(ids[i % ids.Length]);
            }
            stp.Stop();

            Console.WriteLine("{0,-30} - {1,6} ms {2,6} us",
                adapter.Name,
                stp.ElapsedMilliseconds,
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / count, 4));

            adapter.Relase();
        }

        private void TestGetProduct(IAdapter adapter, int count)
        {
            int[] ids = new int[]
            {
                316, 317, 318, 319, 320, 321, 322, 327, 330, 331, 346, 347, 348,
                351, 352,  724
            };

            adapter.Prepare();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = 0; i < count; i++)
            {
                adapter.GetProduct(ids[i % ids.Length]);
            }
            stp.Stop();

            Console.WriteLine("{0,-30} - {1,6} ms {2,6} us",
                adapter.Name,
                stp.ElapsedMilliseconds,
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / count, 4));

            adapter.Relase();
        }

        private void TestGetSimple(IAdapter adapter, int count)
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
                Math.Round(1000.0 * stp.Elapsed.TotalMilliseconds / (5 * count), 4));

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
                List<PersonInfoDto> infos = adapter.GetPagedPersons((count * 10) % 10000, 25);
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
