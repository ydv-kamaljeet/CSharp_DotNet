using System;
namespace kamaljeet;

/// <summary>
/// Employee Class Declaration
/// </summary>
public class Employee
{
#region Member_Variable 
    public int EmpId;
    public string EmpName;
    public string Department;
    public Competition competition;
    
#endregion

    public Employee(int id,string name,string dept,Competition comp)
    {
        EmpId=id;
        EmpName = name;
        Department = dept;
        competition=comp;
    }
    


}