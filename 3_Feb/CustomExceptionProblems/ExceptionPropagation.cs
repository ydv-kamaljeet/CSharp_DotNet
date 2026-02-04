using System;
namespace CustomException;
public class Controller
{
    public static void baseMethod()
    {
        // TODO:
        // Call Service method
        try
        {
            Service.Process();
        }catch(Exception e)
        {
            Console.WriteLine($"Exception catched by Root method.\nException message : {e.Message}");
        }
        // Handle exception here
    }
}

class Service
{
    public static void Process()
    {
       
        // TODO:
        // Call Repository method
        try{
        Repository.GetData();
        }catch(Exception e)
        {
            Console.WriteLine("Exception catched by Process  method.");
            throw;
        }
        // Catch, log and rethrow exception
    }
}


class Repository
{
    public static void GetData()
    {
        Console.WriteLine("Exception thrown by GetData  method.");
        throw new Exception("Exception from GetData method");
    }
}