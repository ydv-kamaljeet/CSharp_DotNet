using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? string.Empty;

            List<string> words = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (words.Count % 2 == 0)
            {
                Console.WriteLine(reverseWord(words));
            }
            else
            {
                Console.WriteLine(reverseCharacters(words));
            }
        }

        public static string reverseWord(List<string> words)
        {
            words.Reverse();
            return string.Join(" ", words);
        }

        public static string reverseCharacters(List<string> words)
        {
            string result = string.Empty;

            foreach (string word in words)
            {
                result += reverseString(word) + " ";
            }

            return result.Trim();
        }

        public static string reverseString(string word)
        {
            char[] chars = word.ToCharArray();
            int i = 0;
            int j = chars.Length - 1;

            while (i < j)
            {
                char temp = chars[i];
                chars[i] = chars[j];
                chars[j] = temp;

                i++;
                j--;
            }

            return new string(chars);
        }
    }
}
