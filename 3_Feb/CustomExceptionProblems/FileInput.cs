using System;
using System.IO;

class FileReader
{
    public static void FileRead()
    {
        string filePath = "data.txt";

        try
        {
            // 1. Read file content
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            } // reader.Close() is called automatically here
        }
        catch (FileNotFoundException)
        {
            // 2. Handle FileNotFoundException
            Console.WriteLine("File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            // 3. Handle UnauthorizedAccessException
            Console.WriteLine("You do not have permission to access this file.");
        }
        catch (Exception ex)
        {
            // Optional: handle any other unexpected error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
