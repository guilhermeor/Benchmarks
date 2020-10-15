using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.Cases
{
    [MemoryDiagnoser]
    public class DictionaryClass
    {
        static Guid id = Guid.NewGuid();
        private readonly Dictionary<Guid, string> DictPersons = new Dictionary<Guid, string>
        {
            {Guid.NewGuid(), "Guilherme" },
            {Guid.NewGuid(), "Luiz" },
            {id, "Jose" },
            {Guid.NewGuid(), "Edenor" },
        };
        readonly List<Person> Persons = new List<Person>
        {
            new Person{Id = Guid.NewGuid(), Name = "Guilherme"},
            new Person{Id = Guid.NewGuid(), Name = "Luiz"},
            new Person{Id = id, Name = "Jose"},
            new Person{Id = Guid.NewGuid(), Name = "Edenor"},
        };

        [Benchmark]
        public string TestWithClass()
        {
            return Persons.FirstOrDefault(p => p.Id == id).Name;
        }

        [Benchmark]
        public string TestWithDict()
        {
            return DictPersons[id];
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
