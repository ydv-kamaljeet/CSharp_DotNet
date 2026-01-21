
namespace Test1;
public class Employee
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public double Salary{get;set;}

//Parameterized constructor
    // public Employee(int id, string name, double salary)
    // {
    //     Id=id;
    //     Name=name;
    //     Salary=salary;
    // }

    //Method to  Get all the details of Employee 
    public void GetDetails()
    {
        Console.WriteLine($"Employee Name : {Name}");
        Console.WriteLine($"Employee Id : {Id} ");
        Console.WriteLine($"Employee Salary : {Salary}");

    }

    public double SecondHighest(List<Employee> employees)
    {
        double Max= employees[0].Salary;
        double secMax=0;
        foreach(Employee p in employees)
        {
            if(p.Salary>Max){
                secMax=Max;
                Max=p.Salary;
            }else if(p.Salary>secMax && p.Salary != Max)
            {
                secMax=p.Salary;
            }
        }
        return secMax;
    }
}