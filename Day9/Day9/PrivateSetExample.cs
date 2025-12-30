namespace Day9;

public class Demo
{
    public int RollNo{get;set;}
    public string Name{get;set;}
   // private string DateOfBirth{get;private set;}

    public Demo(){} //default constructor: need to make it manually , because after creating ctro by own , default will not be created.
    public Demo(string Dob) //if we remove the set while declaring private property, we need to set it using constructor, there is no other way.
    {
      //  DateOfBirth=Dob;
    }

    public void SetDOB(string dob)      //Can be done bacause of private set
    {
      //  DateOfBirth=dob;
    }
}