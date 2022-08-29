using BenchmarkDotNet.Attributes;

namespace CastTest;

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
}