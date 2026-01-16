namespace Jan_15;

public class MeditationCentre
{
    public int Id{get;set;}
    public int Age{get;set;}
    public double Weight{get;set;}
    public double Height{get;set;}
    public string Goal{get;set;}
    public double BMI{get;set;}

    public MeditationCentre(int id,int age,double  wg,double hg,string goal)
    {
        if(wg<=0 || hg<=0)
            throw new Exception ("Invalid Height or Weight Input.");
        Id=id;
        Age=age;
        Weight=wg;
        Height=hg;
        Goal=goal;
    }
   

}