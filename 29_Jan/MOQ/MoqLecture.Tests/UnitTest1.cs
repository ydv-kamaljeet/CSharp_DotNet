using System.Runtime.CompilerServices;
using MoqLecture.Core;
namespace MoqLecture.Tests;

public class Tests
{
    

    [Test]
    public void Test1()
    {
        EmployeeService1 emp = new EmployeeService1(101,"John");
        var result = emp.GetId();
        Assert.That("Version 1 : Id = 101",Is.EqualTo(result));
    }
    [Test]
     public void Test2()
    {
        EmployeeService1 emp = new EmployeeService1(101,"John");
        var result = emp.GetId();
        Assert.That("Version 1 : Id = 11",Is.Not.EqualTo(result));
    }

}

