namespace Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //---------------------- 1. REVERSE STRING 
            //Console.WriteLine(ReverseString(Console.ReadLine()));

            //---------------------- 2. LARGEST ELEMENT IN INTEGER ARRAY 
            //Console.WriteLine(LargestElementInArray(new int[]{4,5,8,2,97,12}));

            //---------------------- 3. REMOVE DUPLICATE FROM LIST
            //List<int> list = new List<int> {1,2,4,6,73,4};
            //RemoveDuplicateUsingHashSet(list);

            //---------------------- 4. CHECK FERQUENCE OF ELEMENT
            //FrequenceOfElement(list);
            
            //---------------------- 5. CHECK IF STRING IS PALINDROME OR NOT
            //Console.WriteLine(IsPalindrome("Madam"));

            //---------------------- 6. FIND SUM OF ALL ELEMENT IN ARRAY
            Console.WriteLine(SumofAllElement(new int[]{1,2,3,4,5}));

            //---------------------- 7. MERGE TWO SORTED ARRAY
            MergeTwoSortedArray(new int[]{1,2,3,4,6} , new int[]{5,7,8,9});


        }


        public static string ReverseString(string str)
        {
            if(str.Length<2) return str;
            char[] arr = str.ToCharArray();
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                char c = arr[left];
                arr[left]=arr[right];
                arr[right]=c;
                left++;
                right--;
            }

            return new string(arr);
        }

        public static int LargestElementInArray(int[] arr)
        {
            if(arr.Length<1) return -1;
            int largestElement = arr[0];
            foreach(int element in arr)
            {
                if(element > largestElement)
                {
                    largestElement=element;
                }

            }
            return largestElement;
        }

        public static void RemoveDuplicateUsingHashSet(List<int> list)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>(list);
            List<int> result =  new List<int>(uniqueNumbers);

            foreach(var element in result)
            {
                Console.WriteLine(element);
            }
        }

        public static void FrequenceOfElement(List<int> list)
        {
            Dictionary<int,int> dict = new Dictionary<int, int>();
            foreach(var element in list)
            {
                if(dict.ContainsKey(element))
                    dict[element]++;
                else
                    dict[element] = 1;
            }

            foreach(var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        public static bool IsPalindrome(string str)
        {
            if(str.Length <2) return true;

            int left = 0;
            int right = str.Length - 1;
            str = str.ToLower();
            while(left < right)
            {
                if(str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public static int SumofAllElement(int[] arr)
        {
            int sum=0;
            foreach(var element in arr)
            {
                sum+=element;
            }
            return sum;
        }

        public static void MergeTwoSortedArray(int[] arr1, int[] arr2)
        {
            int ptr1=0;
            int ptr2=0;
            int i=0;
            int[] result = new int[arr1.Length + arr2.Length];
            while(ptr1<arr1.Length && ptr2 < arr2.Length)
            {
                if(arr1[ptr1] <= arr2[ptr2])
                {
                    result[i++]=arr1[ptr1++];
                    
                }
                else
                {
                    result[i++]=arr2[ptr2++];
                }
            }
            while(ptr1 < arr1.Length)
            {
                result[i++] = arr1[ptr1++];
            }
            while(ptr2 < arr2.Length)
            {
                result[i++] = arr2[ptr2++];
            }
            

            foreach(int element in result)
            {
                Console.WriteLine(element);
            }
        }

        public static void FindFrequenceOfWord(string str)
        {
            string[] words = str.Split(' ');
            Dictionary<string,int> dict = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    
                }
            }
        }

    }

    
}