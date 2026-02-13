namespace BankAccount
{
    public class Account
    {
        public string AccountNumber{get;set;}
        public decimal Balance{get;set;}


        public decimal Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            Balance+=amount;
            return Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            if( amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient Fund");
            }
            Balance-=amount;
            return Balance;
        }

    }
}