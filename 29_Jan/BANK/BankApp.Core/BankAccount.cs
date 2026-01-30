namespace BankApp.Core;

public class BankAccount
{
    private double _balance{get;set;}

    public BankAccount(double initialAmount)
    {
        if(initialAmount <=0 )
            throw new ArgumentException("Inital Balance cannt be less than 0");
        _balance = initialAmount;
    }

    public double Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount cannt be negative or zero");
        }
        _balance += amount;
        return _balance;
    }

    public double Withdraw(double amount)
    {
        if(amount<=0)
            throw new ArgumentException("Withdraw amount cannt be negative or zero");
        else if(amount > _balance)
            throw new InvalidOperationException("Insufficient Balance in you account.");
        
        _balance -= amount;
        return _balance;
    }
}
