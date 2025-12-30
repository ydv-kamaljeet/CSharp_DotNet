using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Day9.PartialClass;
using Day9.PracticeQuestion;
namespace Day9;


public class Program
{
    public static void Main(string[] args)
    {
        #region "Indexer.cs" related operations
        // Data data = new Data(); //creating object
        // //seting values :
        // data[0]="C++";
        // data[1]="Java";
        // data[2]="C#";
        // //geting values : 
        // for( int i=0;i<3;i++)
        // {
        //     Console.WriteLine(data[i]);
        // }
        #endregion
        
        #region "studentIndexer.cs" related Operations"
        // Student s1= new Student(){RollNo=1,Name="Kamal"};
        // s1.SetAddress("Haryana");
        // s1[0]="Programming in Java";
        // s1[1]="Complete Redis Notes";
        // s1[2]="Data Analytics";
        // Student s2= new Student(){RollNo=2,Name="Igloo"};
        // s2.SetAddress("J&K");
        // s2[0]="Programming in C++";
        // s2[1]="Complete Golang Notes";

        // Console.WriteLine($"Student Name : {s1.Name} Roll No : {s1.RollNo} Address : {s1.GetAddress()} \nBooks he have : {s1[0]} , {s1[1]}, {s1[2]}");
        // Console.WriteLine($"Student Name : {s2.Name} Roll No : {s2.RollNo} Address : {s2.GetAddress()} \nBooks he have : {s2[0]} , {s2[1]}");
        #endregion

        #region PartialClass folder operations:
        // ClassA a = new ClassA(){Details="Class A Details",Programming="C#"};
        // a.ShowDetailsfromClassB();
        // a.ShowDetailsfromClassA();
        #endregion

        #region "StaticClass.cs" related operation
        Console.WriteLine($"Value of PI is : {Utility.GetValueOfPI()}");
        #endregion

        #region "PracticeQuestion/BankAccount.cs" realted Operations
        BankAccount ba = new BankAccount(5000){AccountHolderName="Kamal",AccountNumber=1004213};
        ba.Deposit(250);
        ba.WithDraw(1000);

        #endregion
    }
}