using System;
namespace EmployeePayroll
{
    
    public class Employee<Y> where Y : class
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string DOB{get;set;}

        public static List<Employee<Y>> employees = new List<Employee<Y>>();
        public bool  UsernamePasswordChecking<T>(T empId, Y empDOB)
        {
            foreach(var emp in employees)
            {
                if(emp.Id.ToString() == empId.ToString() && emp.DOB.Equals(empDOB))
                {
                    return true;
                }
            }
            return false;
        }

        public double SalaryCalculation(double basicPay)
        {
            double HR = basicPay * 0.2;
            double DA = basicPay * 0.4;
            return (basicPay + HR + DA);

        }
    }
}