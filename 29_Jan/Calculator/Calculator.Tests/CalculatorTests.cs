using NUnit.Framework;
using Calculator.Core;

namespace Calculator.Tests;

[TestFixture]
public class CalculatorTests
{
    private MyCalculator _calc;

    [SetUp] // This runs before every test method
    public void Setup()
    {
        _calc = new MyCalculator();
    }

    [Test]
    public void All_Assertion_Examples()
    {
        // 1. Equality Assertions
        Assert.That(_calc.Addition(2, 2), Is.EqualTo(4));
        Assert.That(_calc.Addition(2, 2), Is.Not.EqualTo(5));

        // 2. Numeric Ranges & Precision
        Assert.That(_calc.Division(10, 3), Is.EqualTo(3.33).Within(0.01));
        Assert.That(_calc.Addition(10, 5), Is.GreaterThan(10));
        Assert.That(_calc.Addition(10, 5), Is.InRange(1, 100));

        // 3. Boolean & Nulls
        Assert.That(true, Is.True);
        Assert.That(false, Is.False);

        // 4. Collection Assertions
        var results = new List<int> { _calc.Addition(1, 2), _calc.Addition(2, 3), _calc.Addition(3, 4) };
        Assert.That(results, Has.Exactly(3).Items);
        Assert.That(results, Contains.Item(3));
        Assert.That(results, Is.Unique);

        // 5. Exception Assertions
        Assert.Throws<DivideByZeroException>(() => _calc.Division(10, 0));
    }

    // Parameterized Tests - Addition (Running the same test with different data)
    [TestCase(5, 3, 8)]
    [TestCase(10, 20, 30)]
    [TestCase(-5, 5, 0)]
    [TestCase(0, 0, 0)]
    public void Addition_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Addition(a, b), Is.EqualTo(expected));
    }

    // Parameterized Tests - Subtraction
    [TestCase(10, 3, 7)]
    [TestCase(20, 5, 15)]
    [TestCase(5, 10, -5)]
    [TestCase(0, 0, 0)]
    public void Subtraction_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Subtraction(a, b), Is.EqualTo(expected));
    }

    // Parameterized Tests - Multiplication
    [TestCase(5, 3, 15)]
    [TestCase(10, 2, 20)]
    [TestCase(-5, 4, -20)]
    [TestCase(0, 100, 0)]
    public void Mulitplication_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Mulitplication(a, b), Is.EqualTo(expected));
    }

    // Parameterized Tests - Division with Precision
    [TestCase(10, 2, 5.0)]
    [TestCase(20, 4, 5.0)]
    [TestCase(15, 3, 5.0)]
    [TestCase(7, 2, 3.5)]
    public void Division_MultipleInputs_ReturnsExpected(int a, int b, double expected)
    {
        Assert.That(_calc.Division(a, b), Is.EqualTo(expected).Within(0.01));
    }

    // Parameterized Tests - Remainder
    [TestCase(10, 3, 1)]
    [TestCase(20, 5, 0)]
    [TestCase(15, 4, 3)]
    [TestCase(7, 2, 1)]
    public void Remainder_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Remainder(a, b), Is.EqualTo(expected));
    }

    // Parameterized Tests - Percentage
    [TestCase(100, 10, 10.0)]
    [TestCase(200, 50, 100.0)]
    [TestCase(50, 20, 10.0)]
    [TestCase(1000, 5, 50.0)]
    public void Percentage_MultipleInputs_ReturnsExpected(int a, int b, double expected)
    {
        Assert.That(_calc.Percentage(a, b), Is.EqualTo(expected).Within(0.01));
    }

    // Exception Tests
    [Test]
    public void Division_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Division(10, 0));
    }

    [Test]
    public void Remainder_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Remainder(10, 0));
    }

    // Range and Boundary Tests
    [Test]
    public void Addition_LargeNumbers_CalculatesCorrectly()
    {
        int result = _calc.Addition(int.MaxValue - 1, 1);
        Assert.That(result, Is.InRange(int.MaxValue - 2, int.MaxValue));
    }

    [Test]
    public void Mulitplication_NegativeNumbers_CalculatesCorrectly()
    {
        int result = _calc.Mulitplication(-5, -3);
        Assert.That(result, Is.GreaterThan(0));
        Assert.That(result, Is.EqualTo(15));
    }
}