namespace LINQ;

public class Example
{
    public void LinqExample()
    {
        string[] names = { "A", "B", "C" };

        //Without LINQ :    {Performance Issue}
        foreach (var item in names)
        {
            if (item == "B") Console.WriteLine("B Found using loop");
        }

        //With LINQ:
        var findName = from nm in names
                        //where nm=="B"
                       select nm.ToLower();

        if (findName != null)
        {
            foreach (var it in findName)
                Console.WriteLine(it);
        }
    }
}