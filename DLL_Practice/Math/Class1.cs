using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using Common;
namespace Math
{


#region Basic operation
public class Calculator
{
    public int Add(int a, int b) => a + b;
}
#endregion

public class MathLogin:CommonAbs
{
    public override void Login(string username,string password)
    {
        Console.WriteLine($"Logged in Math Library Successfully by {username}.");
        
    }
    public override void Logout()
    {
        Console.WriteLine("Logged out from Math Library successfully.");
    }
}
}