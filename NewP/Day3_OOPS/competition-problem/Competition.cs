using System;

namespace kamaljeet;

public class Competition
{
    #region member-variables
    public int CompId;
    public string CompName;
    public List<Employee> participants;
    #endregion

    #region member-function
    public Competition(int id,string name)
    {
        CompId = id;
        CompName=name;
    }

    public void AddParticipant(Employee emp)
    {
     participants.Add(emp);   
    }

    public void ShowRegisteredEmp()
    {
        Console.WriteLine(participants);
    }
    #endregion



}
