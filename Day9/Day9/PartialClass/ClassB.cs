namespace Day9.PartialClass;

public partial class ClassA
{
 public string? Programming{get;set;}
 public void ShowDetailsfromClassB()
    {
        Console.WriteLine("Trying to access the class B content");
        Details="Changed Details of Class A";
        Console.WriteLine($"From Partial class B : {Details}"); //partial class b can access the property of partial class A
        // ShowDetailsfromClassA();   //partial class b can access the methods of partial class A
    }   
   
}