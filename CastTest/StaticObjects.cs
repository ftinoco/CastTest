namespace CastTest;

public class StaticObjects
{
    public static object John = new Person  
    {
        Id = Guid.NewGuid(),
        FullName = "John Doe"
    };

    public static List<object> People = Enumerable
        .Range(0, 10000)
        .Select(x => (object)new Person
        {
            Id = Guid.NewGuid(),
            FullName = Guid.NewGuid().ToString()
        }).ToList();
}