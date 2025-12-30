namespace Day9.PracticeQuestion;
public class BankAccount
{
    public BankAccount(double bal){Balance=bal;}
    public int AccountNumber{get;set;}
    protected double Balance;
    public string AccountHolderName{get;set;}

    public void Deposit(double amount)
    {
        Balance+=amount;
        Console.WriteLine($"Balance After Depost : {Balance}");
    }
    public void WithDraw(double amount)
    {
        Balance-=amount;
        Console.WriteLine($"Balance After Withdraw : {Balance}");

    }

}