using System.Text.RegularExpressions;
namespace Day10;

public class Program
{
    public static void Main(string[] args)
    {
        
        #region "ExtensionMethod.cs" related operation
        // string str = "Madam";
        // string result = str.IsPalindrome()?"Yes, It's a Palindrome":"No, It's not Palindrome";  //our Static methods is now associated with string class.
        // Console.WriteLine(result);
        #endregion

        #region "RegexExample.cs" related operation
        // RegexExample re = new RegexExample();   
        // re.Implement();
        #endregion

        #region "GarbageCollection.cs" related operation
        // GarbageCollection gc = new GarbageCollection();
        // gc.Implement();

        // BigBoy bb = new BigBoy();
        // Console.WriteLine($"Names : {bb.Names[0]} , {bb.Names[1]}");
        // bb.Dispose();
        //Console.WriteLine($"Names : {bb.Names[0]} , {bb.Names[1]}");  //This will throw error because now we have disposed the arraylist.
        #endregion

        MyList list = new MyList();
        list.Add("Kamaljeet");
        list.Add("Igloo");
        list.Add("Sabya");

        Console.WriteLine(list[0]);
        Console.WriteLine(list[1]);
        Console.WriteLine(list[2]);

        Console.WriteLine(list.IndexOf("Iglooo"));



    }
}