using System;
using System.Dynamic;
namespace kamaljeet;

public class Account
{
    public int AccountNumber{get;set;}
    public string Name{get;set;}

    // public  Account(){}
    // public Account(int AccNo,string name)
    // {
    //     this.AccountNumber = AccNo;
    //     this.Name = name;
    // }

    public string GetAccountDetails()
    {
        return "This info is from Base class\n";
    }
}
public class SalesAccount : Account
{
    public string SalesInfo;
    String info = string.Empty;
    public string GetSalesAccountDetails()
    {
        info+=base.GetAccountDetails();
        info+=$"This info is from salesAccount class  and info is {SalesInfo}";
        return info;
    }
}