namespace DigitalWallet.core;

public class WalletInfo
{
    public static string GetAppName()
    {
        return "Digital Wallet System";
    }

    public static void BoxingExample()
    {
        decimal balance = 5000m;

        object boxedBalance = balance;   // BOXING

        Console.WriteLine("Boxed Balance: " + boxedBalance);
        Console.WriteLine("Boxed Balance type : " + boxedBalance.GetType());    //Decimal
        
        decimal unboxedBalance = (decimal)boxedBalance;  // UNBOXING
        Console.WriteLine("Unboxed Balance: " + unboxedBalance);
        Console.WriteLine("unBoxed Balance type : " + unboxedBalance.GetType());    //Decimal




    } 
}
