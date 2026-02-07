using System;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        var service = new TicketService();

        Thread t1 = new Thread(() =>
            Console.WriteLine(service.BookSeat(1, "User1")));

        Thread t2 = new Thread(() =>
            Console.WriteLine(service.BookSeat(1, "User2")));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }

}
