namespace DigitalWallet.core
{
    public class WalletData
    {
        // Value Types
        public int UserId{get;set;}
        public decimal Balance{get;set;}
        public bool IsActive{get;set;}

        // Reference Type
        public string UserName{get;set;}

        // Array to store last transactions
        public decimal[] RecentTransactions{get;set;}
    }
}
