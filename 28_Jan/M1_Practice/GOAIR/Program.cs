namespace GOAIRProblem
{
    public class UserInterface
    {
        public static void Main(string[] args)
        {
            EntryUtility util = new EntryUtility();
            int.TryParse(Console.ReadLine(), out int NumberOfEntries);

            while (NumberOfEntries-- != 0)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Split(':');

                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input format");
                    continue;
                }

                string? empId = parts[0];   
                string? entryType = parts[1];  
                string? stringDuration = parts[2];
                if(int.TryParse(stringDuration, out int duration)){
                    bool flag = false;
                    try{
                    flag = util.ValidateEmployeeId(empId) && util.ValidateDuration(duration);
                    }
                    catch(InvalidEntryException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if(flag)
                        Console.WriteLine("Entry Granted due to Valid Entry details");
                }
            }

        }
    }
}