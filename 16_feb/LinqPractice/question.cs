using System;
using System.Collections.Generic;
using System.Linq;

// 1. The Delegate Definition
public delegate bool BonusCriteria(Employee emp);

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public int Experience { get; set; } // in years
}

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Amit", Salary = 50000, Experience = 3 },
            new Employee { Name = "Priya", Salary = 70000, Experience = 6 },
            new Employee { Name = "Sagar", Salary = 40000, Experience = 2 },
            new Employee { Name = "Riya", Salary = 80000, Experience = 8 }
        };

        // TEST CASE: Calculate total salary of employees with more than 5 years experience
        // The bonus is 10% of their salary.
        double totalBonus = ProcessBonuses(employees, e => e.Experience > 5);

        Console.WriteLine($"Total Bonus Payout: {totalBonus}");
        // Expected Output: 15000 (10% of 70000 + 10% of 80000)
    }

    public static double ProcessBonuses(List<Employee> staff, BonusCriteria crit)
    {
        // YOUR CODE HERE
        // 1. Use LINQ or a loop to find employees matching the criteria 'crit'
        // 2. Calculate 10% of their salary as a bonus
        // 3. Return the sum of those bonuses
        double total =0;
        foreach(var emp in staff){
            if(crit(emp)){
                total+=(emp.Salary*0.1);
            }
        }
        
        return total; // Replace this
    }
}