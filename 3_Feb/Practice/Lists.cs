namespace Practice
{
    public class ListCollection
    {

        public void ExecuteListPractice()
        {
            List<int> list = new List<int>();
            int[] arr = { 10, 20, 30 };
            list.Add(1);
            list.Add(3);
            list.Add(4);            //add element in list
            list.Add(5);
            list.Add(6);

            list.Insert(1, 2);       //1 : Index , 2 : value   =>  list = {1,2,3,4,5,6}
            list.AddRange(arr);     // list = {1,2,3,4,5,6,10,20,30}

            list.Remove(20);         //remove the 1st occurance of 20.      list = {1,2,3,4,5,6,10,30}
            //list.RemoveAll(10);     //Remove all the occurance of 10.       list = {1,2,3,4,5,6,30}
            list.RemoveAt(5);       //Remove the element present at index : 5   list = {1,2,3,4,5,30}
            list.RemoveRange(3, 2);  // 3 : starting index , 2 : no. of elements to remove  list ={1,2,3,30}

            bool found3 = list.Contains(3);
            int idx = list.IndexOf(3);  //1st occurance
            int val = list.Find(x=>x>2);  //1st element that satisfy this condition
            List<int> vals = list.FindAll(x=>x>2);

            list.Sort();    //sort in ascending order
            list.Reverse(); //Not its sorted in descending order

            int lengthOfList = list.Count;



            Console.WriteLine(list.Find(x => x > 3));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}