namespace Practice
{
    public class DictionaryCollection
    {
        public static void ExecuteDictionaryPractice()
        {
            Dictionary<int,string> dict = new Dictionary<int, string>();

            dict.Add(1,"a");
            dict[2]="b";
            //dict.Add(1,"c")   : gives exception as key = 1 already exists in dictinary
            dict.Add(3,"c");
            string value2 = dict[3];
            bool found = dict.TryGetValue(2,out string result);
            Console.WriteLine($"Value of Dict[2] is {result}");

            bool removed = dict.Remove(3);
            bool available = dict.ContainsKey(2);
            bool available2 = dict.ContainsValue("DEF");

            int length = dict.Count;
            dict.Clear();

        }
    }
}