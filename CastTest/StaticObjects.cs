namespace CastTest;

public class StaticObjects
{
    public static object John = new Person  
    {
        Id = Guid.NewGuid(),
        FullName = "John Doe"
    };
}