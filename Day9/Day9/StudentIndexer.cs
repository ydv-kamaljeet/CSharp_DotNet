namespace Day9;

public class Student
{
    public int RollNo{get;set;}
    public string? Name{get;set;}
    private string? Address;
    private List<string>Books = new List<string>(); //For Unlimited Indexing we used List , to bound it to a certain length/size , we can use array.
    public void SetAddress(string addr) //Set the Address
    {   
        Address=addr;
    }
    public string? GetAddress() //get the address
    {   
        return Address;
    }

    //Indexer Declaration:
    public string this[int index]
    {
        get
        {
            return Books[index];
        }
        set
        {
            Books.Add(value);
        }
    }
    

}