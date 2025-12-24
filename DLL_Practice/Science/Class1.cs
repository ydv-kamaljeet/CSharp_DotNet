using Common;
namespace Science{
#region Basic operation
public class Physics
{
    public string Law()
    {
        return "For every action, there is an equal and opposite reaction.";
    }
}
#endregion


public class SciLogin : CommonAbs
{
    public override void Login(string username,string password)
    {
        Console.WriteLine($"Logged in Science Library successfully by {username}.");
    }
    public override void Logout()
    {
        Console.WriteLine("Logged out from Science Library successfully.");
    }

}
}