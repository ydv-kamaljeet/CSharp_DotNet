using System;

class FileUpload
{
    public static void Upload()
    {
        string fileName = "data.txt";
        int fileSize = 8; // MB

        try
        {
            ValidateFile(fileName, fileSize);
            Console.WriteLine("File uploaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload failed: {ex.Message}");
        }
    }

    static void ValidateFile(string fileName, int fileSize)
    {
        // 1. Validate file extension
        if (!fileName.EndsWith(".pdf") && !fileName.EndsWith(".docx"))
        {
            throw new ArgumentException("Invalid file type. Only PDF and DOCX are allowed.");
        }

        // 2. Validate file size
        if (fileSize > 5)
        {
            throw new InvalidOperationException("File size exceeds 8 MB limit.");
        }
    }
}
