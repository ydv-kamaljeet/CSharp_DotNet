using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Practice;

public delegate void Notify();

public  class Implement
{
    public void Execute()
    {
        Notify nf = SMS;
        nf += Mail;
        nf();
    }
    public void SMS()
    {
        Console.WriteLine("Notifying using SMS");
    }
    public void Mail()
    {
        Console.WriteLine("Notifying using EMail");
    }
}
