using BenchmarkDotNet.Running;
using MapperPerformace.Scenarios;
using System;

namespace MapperPerformace
{
    public class Program
    {
        public const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MapperPerformace;Trusted_Connection=True;";
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<MainBenchmark>();
        }
    }
}
