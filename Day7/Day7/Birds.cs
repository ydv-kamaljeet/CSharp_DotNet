namespace Day7;
/// <summary>
/// Interface for Birds who can fly
/// </summary>
public interface IFlyBird
{
    void Fly();
    void Speak();
}
/// <summary>
/// Interface for Birds who can Swim
/// </summary>
public interface ISwimBird
{
    void Swim();
    void Speak();
}


/// <summary>
/// Public class who is implementing these Two interfaces.
/// </summary>
public class Birds : IFlyBird , ISwimBird
{
    public void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
    public void Swim()
    {
        Console.WriteLine("Bird is swiming");
    }
    //From IFlyBird Interface: Interface name is used to differentiate the method, like this speak method is from IFlyBird interface
    void IFlyBird.Speak()
    {
        Console.WriteLine("Bird Who can fly is chirping");
    }
    void ISwimBird.Speak()
    {
        Console.WriteLine("Bird who can Swim is chirping");
    }
}