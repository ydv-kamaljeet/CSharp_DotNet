using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        Department obj = new Department();
        var props = obj.GetType().GetFields(BindingFlags);
    }
}