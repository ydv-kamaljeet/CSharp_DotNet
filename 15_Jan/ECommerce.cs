using System.Reflection.Metadata.Ecma335;

namespace Jan_15;

public class ECommerceShop
{
    public string? Name{get;set;}
    public double WalletBalance{get;set;}
    public double PurchaseAmount{get;set;}

    public ECommerceShop(string name, double bal, double purchase)
    {
        Name=name;
        WalletBalance=bal;
        PurchaseAmount=purchase;
    }
    
}

public class InsufficientWalletBalanceException : Exception
{
    public override string Message => "Insufficient Balance in your Wallet!!!!!!";
}