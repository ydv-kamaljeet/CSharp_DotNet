using System;
using System.Transactions;

namespace MoneyTransaction
{
    public class TransferResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class MoneyTransferService
    {
        public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(fromAcc) ||
                string.IsNullOrWhiteSpace(toAcc))
                throw new ArgumentException("Invalid account");

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            try
            {
                using var scope = new TransactionScope();

                Debit(fromAcc, amount);
                Credit(toAcc, amount);

                WriteAudit($"SUCCESS: {fromAcc} -> {toAcc}, {amount}");

                scope.Complete();

                return new TransferResult
                {
                    Success = true,
                    Message = "Transfer successful"
                };
            }
            catch (Exception ex)
            {
                WriteAudit($"FAILED: {fromAcc}->{toAcc}, {ex.Message}");

                return new TransferResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public void Debit(string acc, decimal amt)
        {
            // DB update simulation
            Console.WriteLine($"Debited {amt} from {acc}");
        }

        public void Credit(string acc, decimal amt)
        {
            // Simulate possible failure
            Console.WriteLine($"Credited {amt} to {acc}");
        }

        public void WriteAudit(string msg)
        {
            Console.WriteLine("AUDIT: " + msg);
        }
    }

}