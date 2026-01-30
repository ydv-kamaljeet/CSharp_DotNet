using System.Data.Common;
using System.Runtime.InteropServices;

namespace MoqLecture.Core;

public class EmployeeService1 : IEmployeeRepository
{
    public int Id{get;set;}
    public string? Name{get;set;}

    public EmployeeService1(int id , string name)
    {
        Id = id;
        Name = name;
    }
    
    public string GetId()
    {
        return $"Version 1 : Id = {Id}";
    }
    public string GetName()
    {
        return $"Version 1 : Name = {Name}";
    }
}


// public class EmployeeService2 : IEmployeeRepository
// {
//     public int Id{get;set;}
//     public string? Name{get;set;}

//     public EmployeeService2(int id , string name)
//     {
//         Id = id;
//         Name = name;
//     }
    
//     public string GetId()
//     {
//         return $"Version 2 : Id = {Id}";
//     }
//     public string GetName()
//     {
//         return $"Version 2 : Name = {Name}";
//     }
// }