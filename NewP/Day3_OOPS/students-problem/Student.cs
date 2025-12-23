using System;
using System.Collections;
namespace kamaljeet;

public class Student
{
    #region Variable Declaration
    public string name;
    public int regNo;
    public string course;
    public string branch;
    #endregion


    #region constructor
    
    public Student(string nm, int reg,string crs, string br)
    {
        name = nm;
        regNo = reg;
        course = crs;
        branch = br;
    }
    #endregion

    #region Member Function
    public void GetDetails()
    {
        Console.WriteLine("Student Name : " + name + "\nStudent Registration Number : "+ regNo+"\nStudent Course : "+course+"\nStudent Branch : "+branch);
    }

    // public void  UpdateDetails()
    // {
    //     Console.WriteLine("To Update - 1 : Name   2 : Registration Number  3 : Course  4 : Branch");
    //     string? choice = Console.ReadLine();
    //     int.TryParse(choice,out int ch);
    //     string? input = Console.ReadLine();
        
    //     switch(ch){
    //         case 1: { 
    //             name = input; 
    //             break;
    //         }
    //         case 2:{ 
    //             int.TryParse(input,out int newRg);
    //             regNo = newRg;
    //             break;
    //         }
    //         case 3:{ 
    //             course = input;
    //             break; 
    //         }
    //         case 4:{ 
    //             branch = input;
    //             break;
    //         }
    //     }
    //     Console.WriteLine("Details updated");
    //     GetDetails();

    // }
    #endregion

}