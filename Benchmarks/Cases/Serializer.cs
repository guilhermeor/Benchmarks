using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceStack;

using JilJson = Jil.JSON;

namespace Benchmarks.Cases
{
    [MemoryDiagnoser]
    public class Serializer
    {
        public List<Dto> Dto = new List<Dto>();
        private readonly int _count = 100000;
        public Serializer()
        {
            for (int i = 0; i < _count; i++)
                Dto.Add(new Dto { Id = i, Key = i * 1000 * new Random().Next() });
        }

        [Benchmark]
        public string ServiceStack() => Dto.ToJson();

        [Benchmark]
        public string Default() => System.Text.Json.JsonSerializer.Serialize(Dto);

        [Benchmark]
        public string Jil() => JilJson.Serialize(Dto);

        [Benchmark]
        public string Newtonsoft() => JsonConvert.SerializeObject(Dto);

        [Benchmark]
        public string Utf8() => Utf8Json.JsonSerializer.ToJsonString(Dto);
    }

    public class Dto
    {
        public int Id { get; set; }
        public int Key { get; set; }
    }
}
