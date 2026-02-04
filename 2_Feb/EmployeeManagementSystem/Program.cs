namespace EmployeeManagementSystem
{
    public class Program
    {
        public static List<Employee> employees = new List<Employee>();
        public static void Main(string[] args)
        {
            HRManager manager = new HRManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Employee Management System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees by Department");
                Console.WriteLine("3. Calculate Department Salary");
                Console.WriteLine("4. Employees Joined After Date");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(manager);
                        break;

                    case "2":
                        DisplayEmployeesByDepartment(manager);
                        break;

                    case "3":
                        CalculateDepartmentSalary(manager);
                        break;

                    case "4":
                        DisplayEmployeesJoinedAfter(manager);
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // ================= MENU ACTIONS =================

        static void AddEmployee(HRManager manager)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Department (HR / IT / Sales): ");
            string dept = Console.ReadLine()!;

            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine()!);

            manager.AddEmployee(name, dept, salary);

            Console.WriteLine("Employee added successfully.");
        }

        static void DisplayEmployeesByDepartment(HRManager manager)
        {
            var grouped = manager.GroupEmployeesByDepartment();

            if (grouped.Count == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            foreach (var dept in grouped)
            {
                Console.WriteLine($"\nDepartment: {dept.Key}");
                foreach (var emp in dept.Value)
                {
                    Console.WriteLine(
                        $"E{emp.EmployeeId:D3} | {emp.Name} | ₹{emp.Salary} | Joined: {emp.JoiningDate:d}"
                    );
                }
            }
        }

        static void CalculateDepartmentSalary(HRManager manager)
        {
            Console.Write("Enter Department Name: ");
            string dept = Console.ReadLine()!;

            double totalSalary = manager.CalculateDepartmentSalary(dept);
            Console.WriteLine($"Total Salary for {dept}: ₹{totalSalary}");
        }

        static void DisplayEmployeesJoinedAfter(HRManager manager)
        {
            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            var employees = manager.GetEmployeesJoinedAfter(date);

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("Employees joined after given date:");
            foreach (var emp in employees)
            {
                Console.WriteLine(
                    $"E{emp.EmployeeId:D3} | {emp.Name} | {emp.Department} | Joined: {emp.JoiningDate:d}"
                );
            }
        }
    }
}