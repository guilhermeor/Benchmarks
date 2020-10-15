using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarks.Cases
{
    [MemoryDiagnoser]
    public class StringCompare
    {
        public string word = "KaKaRoTo ";

        [Benchmark]
        public bool TestWithUpper()
        {
            return string.Equals(word.ToUpper(), "KAKAROTO");
        }

        [Benchmark]
        public bool TestWithLower()
        {
            return string.Equals(word.ToLower(), "kakaroto");
        }

        [Benchmark]
        public bool TestIgnoringCase()
        {
            return string.Equals(word, "kakaroto", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public bool TestIgnoringCase2()
        {
            return string.Equals(word, "KAKAROTO", StringComparison.OrdinalIgnoreCase);
        }
    }
}
