using System;
using System.Collections.Generic;

class Question
{
    public void Check()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        int Count = 0;
        int ptr1 =0;
        int ptr2=0;

        while (ptr2 < word2.Length && ptr1 < word1.Length)
        {
            
            if(word1[ptr1] != word2[ptr2])
            {
                Count++;
                ptr1++;
            }
            else
            {
                ptr1++;
                ptr2++;
            }
        }

        if(ptr2 == word2.Length && ptr1 != word1.Length)
        {
            Count+= word1.Length - ptr1;
        }

        

        
        Console.WriteLine(Count);
    }

    
}
