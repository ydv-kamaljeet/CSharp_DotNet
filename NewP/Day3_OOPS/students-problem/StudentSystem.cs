using System;
using System.Runtime.CompilerServices;
//return $"id= {id}"
namespace kamaljeet;

public class SchoolStudent
{
    public string Name{set;get;}
    public string SchoolName{get;set;}
    public string? Section{get;set;}

  
}
public class UGStudent: SchoolStudent
{
    string Degree{get;set;}
}
public class PGStudent
{
    #region member-variable
    string Specialization{set;get;}
    #endregion
   
}
public class Students
{
    public SchoolStudent school;
    public UGStudent UG;
    public PGStudent PG;

    Students(SchoolStudent sc,UGStudent ug, PGStudent pg)
    {
        school =sc;
        UG=ug;
        PG=pg;

    }
 }