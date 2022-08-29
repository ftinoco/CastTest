using BenchmarkDotNet.Attributes;

namespace CastTest;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Benchmark]
    public Person HardCast()
    {
        Person person = (Person)StaticObjects.John;
        return person;
    }

    [Benchmark]
    public Person SafeCast()
    {
        Person? person = StaticObjects.John as Person;
        return person!;
    }

    [Benchmark]
    public Person MatchCast()
    {
        if (StaticObjects.John is Person person)
        {
            return person;
        }
        return null!;
    }


    /* casting collections */
    [Benchmark]
    public List<Person> OfType()
    {
        return StaticObjects.People
            .OfType<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> Cast_As()
    {
        return StaticObjects.People
            .Where(p => p as Person is not null)
            .Cast<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> Cast_Is()
    {
        return StaticObjects.People
            .Where(p => p is Person)
            .Cast<Person>()
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_As()
    {
        return StaticObjects.People
            .Where(p => p as Person is not null)
            .Select(p => (Person)p)
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_Is()
    {
        return StaticObjects.People
            .Where(p => p is Person)
            .Select(p => (Person)p)
            .ToList();
    }

    [Benchmark]
    public List<Person> HardCast_TypeOf()
    {
        return StaticObjects.People
            .Where(p => p .GetType() == typeof(Person))
            .Select(p => (Person)p)
            .ToList();
    }
}