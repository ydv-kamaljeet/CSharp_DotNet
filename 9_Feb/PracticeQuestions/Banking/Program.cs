namespace Banking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            acc.Deposit(1000);
            acc.Deposit(-1200); //invalid amount
            acc.Withdraw(500);
            acc.Withdraw(1000); //insufficient balance
            acc.Deposit(1200);

            Console.WriteLine("Balance : " + acc.getBalance());
        }
    }
}