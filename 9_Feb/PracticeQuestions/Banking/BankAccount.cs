namespace Banking
{
    public class BankAccount
    {
        private double _balance;

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount cannt be less than 0");
            }
            else
            {
                _balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0 || amount > _balance)
            {
                Console.WriteLine("Invalid amount. Either amount you entered is less than 0 or your account have insufficient balance");
            }
            else{
                _balance -= amount;
            }
        }

        public double getBalance()
        {
            return _balance;
        }
    }
}