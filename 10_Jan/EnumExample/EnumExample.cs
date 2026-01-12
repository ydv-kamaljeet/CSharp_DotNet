namespace Jan10th;

public enum WeekDays
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public enum ProductCategory
{
    Electronic =1,
    Grocery=2
}

public class EnumExample
{
    
    public string GetMenu(WeekDays weekday)
    {
        switch (weekday)
        {
            case WeekDays.Sunday :
                return "Pasta";
            case WeekDays.Monday:
                return "Maggi";
            case WeekDays.Tuesday:
                return "Noodles";
            case WeekDays.Wednesday :
                return "Pasta";
            case WeekDays.Thursday:
                return "Maggi";
            case WeekDays.Friday:
                return "Noodles";
            case WeekDays.Saturday:
                return "Cold drink";
            default :
                return "No Menu";

        }
    }

    public  string GetWeekDay(WeekDays weekday, ref int  numValue)
        {
             numValue = (int)weekday;
            return weekday.ToString();
        }
}