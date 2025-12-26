using System.Buffers;
using System.Runtime.InteropServices;

namespace Day7;

public class Program
{
    public static void Main(string[] args)
    {

        #region working with Birds class 
       //Creating an object of interface type. But eagle and duck{reference variable} are pointing to Bird class object.
        // Birds bird = new Birds();
        // ISwimBird duck = bird;
        // IFlyBird eagle = bird;
        // eagle.Speak();
        // duck.Speak();
        // eagle.Fly();
        #endregion

        if(false){
        Operations op = new Operations();
        
        int input1=int.MaxValue;        //Will not throw integer overflow error , will follow round robin : Max goes back to min.
        int input2=15;
        op.Add(input1,input2);
        Console.WriteLine($"input 1 changed to {input1} and input2 changes into {input2} after addition");  //Here Value of inputs will not change
        op.Addition(ref input1,ref input2);
        Console.WriteLine($"input 1 changed to {input1} and input2 changes into {input2} after addition");  //Here values of input will change
        

        int n=10;
        int square,half,addby3;
        int original = op.MultiMath(n ,out square,out half,out addby3);

        Console.WriteLine($"Original : {original} , Square Value {square} , Half Value {half} , Add By 3 Value {addby3}");

        

        FlipKeys fk = new FlipKeys();
        string result=fk.CleanseAndInvert("Cowages");
        Console.WriteLine(result);
        
        Demo d = new Demo();
        d.JackedArray();
        }

        Collections cl = new Collections();
        cl.Sample();
        
    }
}
