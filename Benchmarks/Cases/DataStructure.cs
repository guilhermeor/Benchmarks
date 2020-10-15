using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.Cases
{
    [MemoryDiagnoser]
    public class DataStructure
    {
        static Guid id = Guid.NewGuid();
        private readonly Dictionary<Guid, string> DictPersons = new Dictionary<Guid, string>
        {
            {Guid.NewGuid(), "Guilherme" },
            {Guid.NewGuid(), "Luiz" },
            {id, "Jose" },
            {Guid.NewGuid(), "Edenor" },
        };
        private readonly HashSet<Person> HashPersons = new HashSet<Person>
        {
            new Person{Id = Guid.NewGuid(), Name = "Guilherme"},
            new Person{Id = Guid.NewGuid(), Name = "Luiz"},
            new Person{Id = id, Name = "Jose"},
            new Person{Id = Guid.NewGuid(), Name = "Edenor"},
        };
        private readonly List<Person> Persons = new List<Person>
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

        [Benchmark]
        public string TestWithHashSet()
        {
            var _ = HashPersons.TryGetValue(new Person { Id = id }, out Person person);
            return person.Name;
        }
    }

    public struct Person : IEqualityComparer<Person>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Person obj)
        {
           return obj.GetHashCode();
        }
    }
}
