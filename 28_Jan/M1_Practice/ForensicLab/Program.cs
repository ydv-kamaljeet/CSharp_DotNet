namespace ForensicLabProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ForensicReport report = new ForensicReport();
             int.TryParse(Console.ReadLine(), out int NumberOfReports);

            while (NumberOfReports-- != 0)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Split(':');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input format");
                    continue;
                }

                string? officer = parts[0];   // "John"
                string? stringDate = parts[1];   // "2024-09-26"
                if(DateOnly.TryParse(stringDate, out DateOnly date))
                    report.AddReportDetails(officer, date);
            }

             if(DateOnly.TryParse(Console.ReadLine(),out DateOnly targetDate)){
                List<string> result = new List<string>();   //Will allocate memory only if input is correct.
                result = report.GetOfficersWhoFiledReportsOnDate(targetDate);
                Console.WriteLine($"Reports filed on {targetDate} are by ");
                if(result.Count() > 0)
                    report.Print(result);
                else
                    Console.WriteLine("Nobody");
            }
        }
    }
}