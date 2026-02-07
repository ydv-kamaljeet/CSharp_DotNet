public class StringReverse
{
    public string Reverse(string str)
    {
        char[] arr = str.ToCharArray();
        int left = 0;
        int right = arr.Length - 1;

        if(arr.Length == 0)
            return "";
        while(left < right)
        {
            var temp = arr[left];
            arr[left]= arr[right];
            arr[right]=temp;
            left++;
            right--;

        }
        string? reversed =  new string(arr);
        return reversed;
    }


    public void CheckFrequence(string str)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char ch in str)
        {
            if (freq.ContainsKey(ch))
                freq[ch]++;
            else
                freq[ch] = 1;
        }

        foreach (var item in freq)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}