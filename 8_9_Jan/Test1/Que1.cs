using System.Security.Cryptography.X509Certificates;

namespace Test1;

public class Person
{
    public string? Name{get;set;}
    public string? Address{get;set;}
    public int Age{get;set;}
}

public class PersonImplementation
{
    public string GetName(IList<Person> persons)
    {
        string result="";
        foreach(Person p in persons)
        {
         result+=$" Name : {p.Name} ";
         result+=$" Address : {p.Address}";
        }
        return result;
    }
    public double Average(IList<Person> persons)
    {
        double avg=0;
        int len=0;
        foreach(Person p in persons)
        {
            avg+=p.Age;
            len++;
        }

        return avg/len;
    }

    public int MaxAge(IList<Person> persons)
    {
        int Max=persons[0].Age;
        foreach(Person p in persons)
        {
            Max=(p.Age>Max)?p.Age:Max;
        }
        return Max;
    }
}