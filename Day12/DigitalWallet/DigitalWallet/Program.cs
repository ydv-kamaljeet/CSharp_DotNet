using System;
using System.Reflection.Metadata;
using DigitalWallet.core;

namespace DigitalWalletApp;
public class Program
{
    public static void Main(string[] args)
    {
        string appName = WalletInfo.GetAppName();
        Console.WriteLine(appName);

        WalletData wallet = new WalletData(); //{UserID=101,USerName="Amit",Balance=5000.50,IsActive=true};

        wallet.UserId=101;
        wallet.UserName="Amit";
        wallet.Balance=5000.50m;
        wallet.IsActive=true;
        wallet.RecentTransactions = new decimal[3];
        wallet.RecentTransactions[0]=500;
        wallet.RecentTransactions[1]=1200;
        wallet.RecentTransactions[2]=300;

        //Value type implementation
        decimal copiedBalance = wallet.Balance;
        copiedBalance = copiedBalance + 500;
        Console.WriteLine("Original Wallet Balance: " + wallet.Balance); // remains unchanged because decimal is value type 
        Console.WriteLine("Copied Balance Value: " + copiedBalance); // copied balanced will be changed


        Console.WriteLine($"USerName : {wallet.UserName} \nBalance : {wallet.Balance} \nWallet Active : {wallet.IsActive}");

        Console.WriteLine("Recent Transaction :");
        for(int i = 0; i < wallet.RecentTransactions.Length; i++)
        {
            Console.WriteLine(wallet.RecentTransactions[i]);
        }

        //reference type implementation:
        WalletData wallet2 = new WalletData();
        wallet2.RecentTransactions = new decimal[2];
        wallet2.RecentTransactions[0] = 200;
        wallet2.RecentTransactions[1] = 300;
        decimal[] copiedTransactions = wallet2.RecentTransactions;
        copiedTransactions[0] = 999;
        Console.WriteLine("Original Transaction Value: " + wallet2.RecentTransactions[0]);  //will change
        Console.WriteLine("Copied Transaction Value: " + copiedTransactions[0]);

        WalletInfo.BoxingExample();

    }
}