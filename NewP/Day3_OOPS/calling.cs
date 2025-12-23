using System;

namespace kamaljeet;

class Calling
{
    public void Function1()
    {
        Calling call = new Calling();

        Men p1 = new Men(1, 22, "Kamaljeet", "Football");
        call.GetDetails(p1);

        Person p2 = new Women(2, 22, "Igloo", "Football and home");
        call.GetDetails(p2);
    }

    public void GetDetails(Person p)
    {
        if (p is Men man)
        {
            Console.WriteLine($"Id: {man.Id}, Name: {man.Name}, Game: {man.Game}");
        }
        else if (p is Women woman)
        {
            Console.WriteLine($"Id: {woman.Id}, Name: {woman.Name}, Role: {woman.PlayAndManage}");
        }
        else
        {
            Console.WriteLine($"Id: {p.Id}, Name: {p.Name}");
        }
    }
}
