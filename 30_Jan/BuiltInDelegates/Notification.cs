using Microsoft.VisualBasic;

namespace DelegateDemo;
public class NotificationSystem
{
    public void ProcessTask<T>(T item , Action<T> action)
    {
        Console.WriteLine("Processing started ....");
        action.Invoke(item);
        Console.WriteLine("Processing Completed....");
    }

    public List<T> FilterData<T>(List<T> items , Predicate<T> condition)
    {
        List<T> result  = new List<T>();
        foreach(var item in items)
        {
            if(condition.Invoke(item))
                result.Add(item);
        }
    }
}

public class Execution
{ 
    public void Execute(){

        //Question 2 : 
        var sys = new NotificationSystem();
        sys.ProcessTask("Order Id 1233", msg=>Console.WriteLine($"{msg} is out for delivery."));
        sys.ProcessTask(1200, Msg => Console.WriteLine($"Total Amount you need to pay {Msg}"));
    }
}