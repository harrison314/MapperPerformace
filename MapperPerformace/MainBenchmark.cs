using BenchmarkDotNet.Attributes;
using MapperPerformace.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformace
{
    [MemoryDiagnoser]
    public class MainBenchmark
    {
        private IScenario scenario;

        [Params(ScenarioName.SelectOneRow, ScenarioName.SelectMany, ScenarioName.StoredProcedureMany)]
        public ScenarioName SelectedScenario;

        [GlobalSetup]
        public void GlobalSetup()
        {
            this.scenario = this.SelectedScenario switch
            {
                ScenarioName.SelectOneRow => new SelectOneRowScenario(Program.ConnectionString),
                ScenarioName.SelectMany => new SelectManyScenario(Program.ConnectionString),
                ScenarioName.StoredProcedureMany=> new StoredProcedureScenario(Program.ConnectionString)
            };
        }

        [Benchmark(Baseline = true)]
        public ValueTask<object> SqlClient()
        {
            return this.scenario.SqlClient();
        }

        [Benchmark]
        public ValueTask<object> Dapper()
        {
            return this.scenario.Dapper();
        }

        [Benchmark]
        public ValueTask<object> EfCore()
        {
            return this.scenario.EfCore();
        }

        [Benchmark]
        public ValueTask<object> EfCoreAsNoTracking()
        {
            return this.scenario.EfCoreAsNoTracking();
        }
    }
}
