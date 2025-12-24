using System;
namespace Emp;


public abstract class Employee
{
    public abstract double CalcTax(double income);
    
}
public class UsEmployee:Employee
{
    public override double CalcTax(double income)
    {
        return income*0.1;
    }
}

public class IndianEmployee:Employee
{
    public override double CalcTax(double income)
    {
        if(income>1200000)
            return income*0.3;
        return 0;
    }
}