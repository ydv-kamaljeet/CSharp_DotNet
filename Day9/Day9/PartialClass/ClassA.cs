namespace Day9.PartialClass;

public partial class ClassA
{
    public String? Details{get;set;}

    public void ShowDetailsfromClassA()
    {
        
        Console.WriteLine("Trying to access the class B content");
        Programming="Java";
        Console.WriteLine($"From Partial Class A : {Programming}");

    }
}