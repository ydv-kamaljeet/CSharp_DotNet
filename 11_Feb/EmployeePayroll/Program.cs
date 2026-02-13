using System;

namespace EmployeePayroll
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize the data
            Employee<string> empService = new Employee<string>();
            Employee<string>.employees.Add(new Employee<string> { Id = 180315, Name = "Rosy", DOB = "10/07/1999" });
            Employee<string>.employees.Add(new Employee<string> { Id = 180316, Name = "David", DOB = "05/03/1998" });
            Employee<string>.employees.Add(new Employee<string> { Id = 180317, Name = "Peter", DOB = "12/12/2000" });

            Console.WriteLine("Enter the user name");
            string inputId = Console.ReadLine();
            
            Console.WriteLine("Enter the password");
            string inputDOB = Console.ReadLine();

            // Perform Validation
            if (empService.UsernamePasswordChecking(inputId, inputDOB))
            {
                Console.WriteLine("Enter the basic pay");
                double basicPay = double.Parse(Console.ReadLine());
                double totalSalary = empService.SalaryCalculation(basicPay);
                Console.WriteLine("The employee's total salary is " + totalSalary);
            }
            else
            {
                Console.WriteLine("Invalid user name or password");
            }
        }
    }
}