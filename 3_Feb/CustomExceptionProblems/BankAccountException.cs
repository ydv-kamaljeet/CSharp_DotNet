namespace CustomException
{
    public class BankAccount
    {
        public void Withdraw()
        {
            int balance = 1000;
            Console.WriteLine("Enter withdrawal amount:");
            int amount = int.Parse(Console.ReadLine());
            bool status = true;
            try{
                if(amount<=0)
                    throw new InvalidWithdrawalAmountException();
                else if(amount>balance)
                    throw new InsufficientBalanceException();
                else
                    balance -= amount;
                
            }
            catch(InvalidWithdrawalAmountException e)
            {
                Console.WriteLine(e.Message);
                status=false;
            }
            catch(InsufficientBalanceException e)
            {
                Console.WriteLine(e.Message);
                status=false;
            }
            finally
            {
                if(status)
                    Console.WriteLine($"Transaction completed successfully.\nYour current Balance is {balance}");
                else
                    Console.WriteLine("Transaction failed.");
            }
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public override string Message => "Insufficient Balance in your account,PLease  Top up your account ";
    }
    public class InvalidWithdrawalAmountException : Exception
    {
        public override string Message => "Withdrawal account cannt be negative or zero, enter valid amount. ";
    }
}