using System;

namespace kamaljeet;

/// <summary>
/// Generalized class defination to implement Constructor overloading
/// </summary>
public class Visitor
{
    public int ID{get;set;}
    public string Name{get;set;}
    public string Requirement{get;set;}
    public string LogHistory{get;set;}

public Visitor()
    {
        LogHistory+=$"Object is created at {DateTime.Now.ToString()} ... {Environment.NewLine}";
    }
    public Visitor(int id) : this()
    {
        LogHistory+=$"ID is created at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        ID=id;
    }
    public Visitor(string name) : this()
    {
        string lname = name.ToLower();
        if (lname.Contains("idiot"))
        {
            throw new ArgumentException ("You cannt write these stupid words");
        }
        LogHistory+=$"Name is stored at {DateTime.Now.ToString()} ... {Environment.NewLine}";
        Name=name;
    }
    public Visitor(int id,string name,string address) : this(id)
    {
        ID=id;
        Name=name;
        Requirement=address;
        LogHistory+=$"Name and requirements is strored at {DateTime.Now.ToString()} ... {Environment.NewLine}";

    }

    public void ShowDetails()
    {
        Console.WriteLine($"Id : {ID}  \nName : {Name}  \nReq : {Requirement}");
        Console.WriteLine(LogHistory);
    }
}

class Employees
{
    private int ID;

    public int Id {
        set{
            if(value>0) ID= value;
            else {
                ID=0;
                throw new InvalidOperationException("How Id can be less then Zero");
            }
        }
    }
}


#region Addition using Constructor
/// <summary>
/// class defination 
/// </summary>
class Addition
{
    public int Num1{get;set;}
    public int Num2{get;set;}
    public int Result{get;}     //result  should be set to get only, not Set beacuse user should not be able to set the result value .
    public string AdditionLogs{set;get;}
    private Addition(){}
    /// <summary>
    /// constructor to add the numbers given in parameter while creating object
    /// </summary>
    /// <param name="n1">Number 1</param>
    /// <param name="n2">Number 2</param>
    public Addition(int n1,int n2)
    {
        Result=n1+n2;   //get properties (i.e result) can  set only in constructor.
        Console.WriteLine($"Addition of these 2 numbers is : {Result}");
        Num1=n1;
        Num2=n2;
        AdditionLogs+=$"Addtion is done at {DateTime.Now.ToString()}";
    }
}



#endregion