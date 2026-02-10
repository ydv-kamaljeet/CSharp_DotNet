using System.Reflection;
namespace ReflectionExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp = new Employee();

            Type t = typeof(Employee);

            // Console.WriteLine("---- Properties ----");

            // foreach (var prop in t.GetProperties(
            //     BindingFlags.Public |
            //     BindingFlags.NonPublic |
            //     BindingFlags.Instance))
            // {
            //     Console.WriteLine(prop.Name);

            //     if (prop.CanRead)
            //     {
            //         var value = prop.GetValue(emp);
            //         Console.WriteLine($"Value: {value}");
            //     }
            // }

            // Console.WriteLine("Methods");

            // foreach (var method in t.GetMethods(
            //     BindingFlags.Public |
            //     BindingFlags.NonPublic |
            //     BindingFlags.Instance |
            //     BindingFlags.DeclaredOnly))
            // {
            //     Console.WriteLine(method.Name);
            // }

            // Console.WriteLine("Calling Private Method:");

            // MethodInfo m = t.GetMethod(
            //     "PrivateMethod",
            //     BindingFlags.NonPublic | BindingFlags.Instance);

            // m.Invoke(emp, null);

            MethodInfo[] m = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach( var method in m)
            {
                if (method.GetParameters().Length == 0)
                    method.Invoke(emp,null);
            }
        }
    }



    public class Employee
    {
        public string Name { get; set; } = "Kamal";

        private int Salary { get; set; } = 50000;

        public void PublicMethod()
        {
            Console.WriteLine("Public method called");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private method called");
        }
    }

}