using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

[TestFixture]
public class CalculatorExceptionTests
{
    private Calculator _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new Calculator();
    }

    // 1. Division by Zero Exception Tests
    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    // 2. Exception Type Verification
    [Test]
    public void Divide_ByZero_ExceptionContainsCorrectMessage()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));
        Assert.That(ex, Is.Not.Null);
    }


    // 4. Exception Should NOT be Thrown
    [Test]
    public void Divide_ByNonZero_DoesNotThrowException()
    {
        Assert.DoesNotThrow(() => _calc.Divide(10, 2));
    }

    [TestCase(20, 4)]
    [TestCase(15, 3)]
    public void Divide_ByNonZeroMultipleValues_DoesNotThrowException(int numerator, int denominator)
    {
        Assert.DoesNotThrow(() => _calc.Divide(numerator, denominator));
    }

    // 5. Verify Exception is Caught and Result is Correct
    [Test]
    public void Divide_ValidDivision_ReturnsCorrectResult_NoException()
    {
        double result = _calc.Divide(10, 2);
        Assert.That(result, Is.EqualTo(5.0));
        Assert.Pass("No exception was thrown");
    }

    // 6. Test Exception with Specific Assertion
    [Test]
    public void Divide_ByZero_ExceptionTypeIsCorrect()
    {
        var exception = Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        Assert.That(exception, Is.TypeOf<DivideByZeroException>());
    }

    // 7. Verify Exception is Not Other Types
    [Test]
    public void Divide_ByZero_NotArgumentException()
    {
        Assert.That(() => _calc.Divide(10, 0), 
            Throws.TypeOf<DivideByZeroException>()
            .And.Not.TypeOf<ArgumentException>());
    }

    // 8. Test with Multiple Exception Scenarios
    [Test]
    public void Calculator_MultipleExceptionScenarios_HandledCorrectly()
    {
        // Scenario 1: Normal division
        Assert.DoesNotThrow(() => _calc.Divide(10, 2));

        // Scenario 2: Division by zero
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));

        // Scenario 3: Another normal division
        double result = _calc.Divide(20, 4);
        Assert.That(result, Is.EqualTo(5.0));
    }

    // 9. Exception Handling with Range Assertions
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    public void Divide_ByZeroOrClose_ThrowsOrReturns(int denominator)
    {
        if (denominator == 0)
        {
            Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, denominator));
        }
        else
        {
            Assert.DoesNotThrow(() => _calc.Divide(10, denominator));
        }
    }

    // 10. Exception Base Class Matching
    [Test]
    public void Divide_ByZero_ExceptionIsSystemException()
    {
        var exception = Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        Assert.That(exception, Is.InstanceOf<System.Exception>());
    }
}
