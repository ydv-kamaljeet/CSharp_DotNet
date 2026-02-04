using System;
using System.Linq;
using System.Text;

public class FlipKey
{
    /// <summary>
    /// Cleanses the input string, filters characters based on ASCII value,
    /// reverses the result, and converts alternate characters to uppercase.
    /// </summary>
    /// <param name="input">Input string provided by the user</param>
    /// <returns>Processed string after applying all transformations</returns>
    public string CleanseAndInvert(string input)
    {
        // Validate input: return empty string if null or length is less than 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return string.Empty;
        }

        // Convert the input string to lowercase
        input = input.ToLower();

        // StringBuilder is used for efficient string concatenation
        StringBuilder sb = new StringBuilder();

        // Traverse each character in the input string
        foreach (char ch in input)
        {
            // Check if character is a lowercase alphabet
            if (ch >= 'a' && ch <= 'z')
            {
                // Add character only if its ASCII value is odd
                if ((int)ch % 2 != 0)
                {
                    sb.Append(ch);
                }
            }
        }

        // Reverse the filtered string
        string reversed = new string(sb.ToString().Reverse().ToArray());

        // Convert string to character array for modification
        char[] characters = reversed.ToCharArray();

        // Convert characters at even indices to uppercase
        for (int i = 0; i < characters.Length; i++)
        {
            if (i % 2 == 0)
            {
                characters[i] = char.ToUpper(characters[i]);
            }
        }

        // Return the final processed string
        return new string(characters);
    }
}

public class Program
{
    public static void Main()
    {
        // Create an object of FlipKey class
        FlipKey flipKey = new FlipKey();

        // Read input from the user
        string input = Console.ReadLine() ?? string.Empty;

        // Call the CleanseAndInvert method and print the result
        Console.WriteLine(flipKey.CleanseAndInvert(input));
    }
}
