namespace OnBoarding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp1 = new Employee(1,"Kamaljeet","kyjeetudsfsgamil.com",90000);
            Employee emp2 = new Employee(2,"Kamaljeet","kyjeetu@gamil.com",0);
            Employee emp3 = new Employee(3,"Kamaljeet","kyjeetu@gamil.com",70000);
            Console.WriteLine($" Id : {emp1.Id} | Name : {emp1.Name} | Salary = {emp1.Salary} | Email : {emp1.Email}");
            Console.WriteLine($" Id : {emp2.Id} | Name : {emp2.Name} | Salary = {emp2.Salary} | Email : {emp2.Email}");
            Console.WriteLine($" Id : {emp3.Id} | Name : {emp3.Name} | Salary = {emp3.Salary} | Email : {emp3.Email}");
        }
    }
}