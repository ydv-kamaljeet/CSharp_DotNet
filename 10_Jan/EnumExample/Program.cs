using System.ComponentModel;

namespace Jan10th;

public class Program
{
    public static void Main(string[] args)
    {
        WeekDays today = WeekDays.Wednesday;
        Console.WriteLine("Todays Day is " + today);

        //int enumValue = (int)WeekDays.Friday;
        //ProductCategory category = ProductCategory.Electronics;
        //Console.WriteLine("Selected category: " + category + " with value " + (int)category);
        int numValuePara = 0;
        EnumExample en = new EnumExample();
        string variableForDay = en.GetWeekDay(WeekDays.Thursday, ref numValuePara);
        Console.WriteLine(variableForDay);
        Console.WriteLine(numValuePara);    //Got 4 because thursday is on 4Th index position

        Console.WriteLine("Todays Menu is "+en.GetMenu(WeekDays.Monday));

        College cg = new College();
        cg.SetDetails();
        cg.GetDetails();
    }
}
