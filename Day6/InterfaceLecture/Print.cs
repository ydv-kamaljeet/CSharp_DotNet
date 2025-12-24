
namespace InterfaceLecture;

public interface IPrint
{
    public void PrintScreen();
}


public class HomePage : IPrint
{
    public int PageNumber{get;set;}
    public string Header{get;set;}
    public HomePage(int pg,string header)
    {
        PageNumber =pg;
        Header=header;
    }
    public void PrintScreen()
    {
        Console.WriteLine("HomePage is printing");
    }
    public void showDetails()
    {
        
    }
}