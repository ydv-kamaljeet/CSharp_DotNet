using System;

class DatabaseConnection
{
    public static void Connect()
    {
        bool isConnectionOpen = false;

        try
        {
            // 1. Open connection
            Console.WriteLine("Opening database connection...");
            isConnectionOpen = true;

            // 2. Simulate operation failure
            throw new Exception("Database operation failed");

            // (This line will never execute)
            // Console.WriteLine("Operation successful");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // 3. Ensure connection is closed
            if (isConnectionOpen)
            {
                Console.WriteLine("Closing database connection...");
                isConnectionOpen = false;
            }
        }

        Console.WriteLine("Program completed.");
    }
}
