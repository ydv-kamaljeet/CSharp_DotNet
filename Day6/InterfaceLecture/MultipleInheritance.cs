namespace InterfaceLecture;

public interface IVegEater
{
    void EatVeg();
    void Taste();
}
public interface INonVegEater
{
    void EatNonVeg();
    void Taste();
}

public class Visitor : IVegEater, INonVegEater
{
    public void EatVeg()
    {
        Console.WriteLine("\n\nVisitor is Vegetarian");
    }
    public void EatNonVeg()
    {
        Console.WriteLine("Visitor is Non Vegetarian");
    }
     void IVegEater.Taste()
    {
        Console.WriteLine("Savory");
    }

    void INonVegEater.Taste()
    {
        Console.WriteLine("Spicy");
    }
}
