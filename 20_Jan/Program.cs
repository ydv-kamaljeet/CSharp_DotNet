// Example pattern: a ref struct with Dispose method
namespace Jan20;
public class Program
{
    public ref struct TempBuffer
    {
        // public void Dispose()
        // {
        //     // cleanup logic (concept)
        // }
        public void Print()
        {
            Console.WriteLine("Hello.");
        }
    }

    public static void UseBuffer()
    {
        // C# 8.0: using works with ref struct (pattern-based)
        using var buf = new TempBuffer();
        buf.Print();
        // work with buf
        TempBuffer.Dispose();
    }

    public static void Main(string[] args)
    {
        UseBuffer();
    }

}