namespace TechStoreProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GadgetValidatorUtil util = new GadgetValidatorUtil();
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

                string? gadgetId = parts[0];   
                string? gadgetType = parts[1];  
                string? stringPeriod = parts[2];
                if(int.TryParse(stringPeriod, out int period)){
                    bool flag = false;
                    try{
                    flag = util.ValidateGadgetID(gadgetId) && util.ValidateWarrantyPeriod(period);
                    }
                    catch(InvalidGadgetException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if(flag)
                        Console.WriteLine("Warranty accepted, stock updated");
                }
            }

        }
    }
}