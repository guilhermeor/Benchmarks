using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Cases;
using System;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Serializer>();
            Console.ReadLine();
        }
    }
}