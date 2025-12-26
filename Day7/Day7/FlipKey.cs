namespace Day7{
public class FlipKeys{

    /// <summary>
    /// Member function to reverse the string.
    /// </summary>
    /// <param name="res"> string you want to reverse</param>
    /// <returns></returns>
    public string ReverseString(string res)
        {
            char[] arr = res.ToCharArray();
            Array.Reverse(arr);
            string result = new string(arr);
            return result;
        }

    /// <summary>
    /// Memeber function of class FlipKeys to generate the strong password by performing some operation on given string.
    /// </summary>
    /// <param name="input">string input</param>
    /// <returns></returns>
    public string CleanseAndInvert(string input)
    {
        int len = input.Length;
        if(len < 6) return "Invalid Input";
        string res=string.Empty;
        //operation - 1
        input=input.ToLower();
        //opertion - 2
        for(int i = 0; i < len; i++)
        {
            int ascii = (int)input[i];

            if((ascii >=48 && ascii<=57) || (ascii>=97 && ascii<=122)){
                if (ascii % 2 != 0)
                {
                    res+=input[i];
                }
            }
            else
            {
                return "Invalid Input";
            }
        }

        //operation - 3
        string result = ReverseString(res);

        //operation - 4
        string FinalResult="";
        for(int i = 0; i < result.Length; i++)
        {
            if(i%2==0)
                FinalResult+=char.ToUpper(result[i]);
            else FinalResult+=result[i];       
        }


        return FinalResult; //returning the final string after performing these 4 operations.
    }
}
}