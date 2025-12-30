using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Day7;

public class Collections
{
    public void Sample()
    {
if(false){
    #region ArrayList
        ArrayList mylist = new ArrayList();
        mylist.Add(10);
        mylist.Add("Hello");
        mylist.Add(89.08);

        foreach (var item in mylist)
        {
            Console.WriteLine(item);
        }
    #endregion

    #region Stack Operation
        Stack st = new Stack();
        st.Push(89);
        st.Push("World");
        st.Push(3.14);

        if (st.Count > 0)
        {
            if(st.Pop() is int)
            {
                int val = (int)st.Pop();
            }
        }
    #endregion

    #region Queue
        Queue q = new Queue();
        q.Enqueue(1);
        q.Dequeue();
        q.Enqueue("Guest");
    #endregion
}
        // Stack<Student> students = new Stack<Student>;
        // Student s1 = new Student(){Id=1,Name="Kamal"};
        // students.Push(s1);
        // Student s2 = new Student(){Id=2,Name="Igllo"};
        // students.Push(s2);
        // foreach(var item in students)
        // {
        //     Console.WriteLine(item);
        // }


    }
}

public class Student
{
        public int Id{get;set;}
        public string Name{get;set;}
}