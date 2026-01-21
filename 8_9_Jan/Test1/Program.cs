using System.Net.Sockets;
using System.Security.Cryptography;

namespace Test1;

public class Program
{
    public static void Main(string[] args)
    {

        #region Question 1:

        // IList<Person> list = new List<Person>();
        // list.Add(new Person{Name="Kamal",Address="Hr",Age=20});
        // list.Add(new Person{Name="Igloo",Address="BR",Age=29});
        // list.Add(new Person{Name="Luffy",Address="NP",Age=22});
        // PersonImplementation pi = new PersonImplementation();
        // string res = pi.GetName(list);
        // Console.WriteLine(res);
        // Console.WriteLine("Average Age : "+pi.Average(list));
        // Console.WriteLine("Maximum Age : "+pi.MaxAge(list));

        #endregion

        // Source sc = new Source();
        // sc.Add(1,2,3);
        // sc.Add(12.5,2.5,3.0);
        Employee emp = new Employee();
        List<Employee> list = new List<Employee>();
        list.Add( new Employee(){Id=101,Name="Kamaljeet",Salary=5000}); //Object creation of Employee class
       list.Add( new Employee(){Id=102,Name="Kamaljeet",Salary=7000});
       list.Add( new Employee(){Id=100,Name="Kamaljeet",Salary=4000});
        Console.WriteLine(emp.SecondHighest(list));
    } 
}