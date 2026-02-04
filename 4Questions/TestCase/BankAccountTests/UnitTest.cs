using NUnit.Framework;
using System;
using BankAccountApp;

[TestFixture]
public class UnitTest
{
    /// <summary>
    /// Verifies that depositing a valid amount
    /// correctly increases the account balance.
    /// </summary>
    [Test]
    public void Deposit_WithValidAmount_ShouldIncreaseBalance()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Deposit(500m);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(1500m));
    }

    /// <summary>
    /// Verifies that depositing a negative amount
    /// throws an exception with the correct message.
    /// </summary>
    [Test]
    public void Deposit_WithNegativeAmount_ShouldThrowException()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act & Assert
        Exception ex = Assert.Throws<Exception>(() => account.Deposit(-100m))!;
        Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
    }

    /// <summary>
    /// Verifies that withdrawing a valid amount
    /// correctly decreases the account balance.
    /// </summary>
    [Test]
    public void Withdraw_WithValidAmount_ShouldDecreaseBalance()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Withdraw(400m);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(600m));
    }

    /// <summary>
    /// Verifies that withdrawing more than the available balance
    /// throws an exception with the correct message.
    /// </summary>
    [Test]
    public void Withdraw_WithInsufficientFunds_ShouldThrowException()
    {
        // Arrange
        Program account = new Program(300m);

        // Act & Assert
        Exception ex = Assert.Throws<Exception>(() => account.Withdraw(500m))!;
        Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
    }
}
