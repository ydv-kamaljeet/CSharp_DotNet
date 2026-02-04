using Microsoft.VisualBasic;

namespace EmployeeManagementSystem
{
    public class HRManager
    {
        private static int count=1;
        public void AddEmployee(string name, string dept, double salary)
        {
            Employee emp = new Employee
            {
                EmployeeId = count++,
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Now
            };
            Program.employees.Add(emp);
        }


        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string,List<Employee>> groupedEmp = new SortedDictionary<string, List<Employee>>();
            foreach(var emp in Program.employees)
            {
                if (!groupedEmp.ContainsKey(emp.Department))
                {
                    groupedEmp[emp.Department] = new List<Employee>();
                }
                groupedEmp[emp.Department].Add(emp);
            }
            return groupedEmp;
        }


        public double CalculateDepartmentSalary(string department)
        {
            double TotalSalary = 0;
            foreach(var emp in Program.employees)
            {
                if(emp.Department == department)
                {
                    TotalSalary+=emp.Salary;
                }
            }
            return TotalSalary;
        }

        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> SameBatchEmp = new List<Employee>();

            foreach(var emp in Program.employees)
            {
                if(emp.JoiningDate > date)
                {
                    SameBatchEmp.Add(emp);
                }
            }
            return SameBatchEmp;
        }
    }
}