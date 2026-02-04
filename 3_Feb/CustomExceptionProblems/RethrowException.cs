using System;

class ExceptionRethrow
{
    public static void BaseMethod()
    {
        try
        {
            ProcessData();
        }
        catch (Exception e)
        {
            // TODO:
            // Handle final exception
            Console.WriteLine($"Exception caught by BaseMethod.\nException Message : {e.Message}");
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception)
        {
            // TODO:
            // Log exception
            Console.WriteLine("Exception caught and rethrown by ProcessData method");
            // Rethrow while preserving stack trace
            throw;
        }
    }
}