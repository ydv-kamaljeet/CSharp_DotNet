using NUnit.Framework;
using BankApp.Core;

namespace BankApp.Tests;

[TestFixture]
public class BankAccountTests
{
    private BankAccount _account;

    [SetUp]
    public void Setup()
    {
        _account = new BankAccount(1000);
    }

    [Test]
    public void Constructor_WithValidAmount_CreatesAccount()
    {
        Assert.DoesNotThrow(() => new BankAccount(500));    //if this BankAccount() constructor throw any error , this test will fail.
    }

    [TestCase(0)]
    [TestCase(-100)]
    public void Constructor_WithInvalidAmount_ThrowsArgumentException(double amount)
    {
        Assert.Throws<ArgumentException>(() => new BankAccount(amount));
    }

    [Test]
    public void Deposit_WithValidAmount_IncreaseBalance()
    {
        double result = _account.Deposit(500);
        Assert.That(result, Is.EqualTo(1500));
    }

    [TestCase(0)]
    [TestCase(-100)]
    public void Deposit_WithInvalidAmount_ThrowsArgumentException(double amount)
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(amount));
    }

    [Test]
    public void Withdraw_WithValidAmount_DecreaseBalance()
    {
        double result = _account.Withdraw(300);
        Assert.That(result, Is.EqualTo(700));
    }

    [Test]
    public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(1500));
    }

    [TestCase(0)]
    [TestCase(-100)]
    public void Withdraw_WithInvalidAmount_ThrowsArgumentException(double amount)
    {
        Assert.Throws<ArgumentException>(() => _account.Withdraw(amount));
    }

    [Test]
    public void Withdraw_ExactBalance_ReturnsZero()
    {
        double result = _account.Withdraw(1000);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void DepositAndWithdraw_MultipleOperations_BalanceCorrect()
    {
        _account.Deposit(500);
        double result = _account.Withdraw(300);
        Assert.That(result, Is.EqualTo(1200));
    }
}


