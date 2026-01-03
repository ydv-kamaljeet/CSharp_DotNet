namespace Day10;

public static  class ExtensionMethods
{
    /// <summary>
    ///  It's a special type of static method that allows you to add new methods to an existing type
    ///  (such as a class, struct, or interface) without modifying its source code, recompiling it, 
    ///  or creating a derived type. 
    /// </summary>
    /// <param name="str">Text</param>
    /// <returns></returns>
    public static bool IsPalindrome(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))     return false;
        int len=str.Length;
        for(int i = 0; i<len; i++)
        {
            if(char.ToUpperInvariant(str[i]) != char.ToUpperInvariant(str[len-i-1]))return false;
        }
        return true;
    }
}