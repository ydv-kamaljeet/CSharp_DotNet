using System;
using System.Dynamic;
using System.Security.Principal;
namespace kamaljeet;

public class Associate
{
    #region Attributes
    public int Id{get;set;}
    public int Rank{get;set;}
    public string Name{get;set;}
    #endregion 

    #region Member function
    public Associate(int id,int rank,string name)
    {
        string Error="";

        //checking constraints
        if (id < 0)
        {
            Error+="Id cannt be less than zero\n";
        }
        if(rank<0) Error+="Rank cannt be Negative\n";
        if(name=="") Error+=" Name field cann't be empty\n";

        //Assigning values
        this.Id=id;
        this.Rank=rank;
        this.Name=name;

        //If error is there, we need to throw it.
        if (Error!=""){
            throw new Exception(Error);
        }
    }
    #endregion
    
    

}
