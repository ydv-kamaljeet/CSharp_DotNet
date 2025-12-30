namespace Day9{

/// <summary>
/// Simple class having indexer properties.
/// </summary>
public class Data
{
    private string[] values = new string[3];

    //Indexer:
    public string this[int index]
    {
        get
        {
            return values[index];       //Use : console.Write(obj[1]);
        }
        set
        {
            values[index]=value;        //use : obj[0]="Kamal";
        }
    }
}
}