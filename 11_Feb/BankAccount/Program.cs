namespace BankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Account acc = new Account{AccountNumber = "101",Balance = 1000m};
            
            try{
                Console.WriteLine($"Amount is credited. Current Balance : {acc.Deposit(500)}");
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine($"Amount is debited. Current Balance : {acc.Withdraw(7000)}");
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}