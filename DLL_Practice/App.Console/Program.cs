using System;
using Math;
using Science;
using Common;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            // Calculator c = new Calculator();
            // Console.WriteLine(c.Add(2, 3));
            // Physics p = new Physics();
            // Console.WriteLine(p.Law());
            
            // SciLogin lg = new SciLogin();
            // lg.Login("Kamaljeet","Jetu");

            Payment p = new UPIPayment(2000,"kamaljeet@axl");
            p.Pay();
            p.PrintReceipt();
            Payment bt = new BankTransfer(1221090243,500);
            bt.Pay();
            bt.PrintReceipt();

        }
    }
}
