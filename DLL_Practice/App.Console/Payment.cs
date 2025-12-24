namespace AppConsole;
//This file is to Implement runtime Polymorphism

/// <summary>
/// General/Base class. 
/// </summary>
public abstract class Payment
{
    public decimal Amount{get;set;}

    protected Payment(decimal amt)
    {
        this.Amount = amt;
    }
    public void PrintReceipt()
    {
        Console.WriteLine($"Payment Receipt - Amount: {Amount} is deducted from your account.");
    }
    public abstract void Pay();
}


public class UPIPayment : Payment
{
    public string UpiId{get;set;}
    public UPIPayment(decimal amt, string id) : base(amt)
    {
        this.UpiId=id;
    }
    public override void Pay()
    {
        Console.WriteLine($"Payment Done\n{Amount} Rs. is transfered to {UpiId} UPI.");
    }
}


public class BankTransfer : Payment
{
    public int AccountNumber{get;set;}

    public BankTransfer(int AccNum,decimal amt) : base(amt)
    {
        this.AccountNumber=AccNum;
    }

    public override void Pay()
    {
        Console.WriteLine($"Payment Done\nPaid {Amount} Rs. to Account number : {AccountNumber}");
    }
}