namespace Meeting
{
    public class UserInterface
    {
        public static void Main(string[] args)
        {
            
            try
            {
                Console.Write("Enter customer name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter employment type: ");
                string? employmentType = Console.ReadLine();

                Console.Write("Enter monthly income: ");
                int monthlyIncome = int.Parse(Console.ReadLine());

                Console.Write("Enter existing credit dues: ");
                int dues = int.Parse(Console.ReadLine());

                Console.Write("Enter credit score: ");
                int creditScore = int.Parse(Console.ReadLine());

                Console.Write("Enter number of loan defaults: ");
                int defaults = int.Parse(Console.ReadLine());

                // Execution Section
                CreditRiskProcessor cr = new CreditRiskProcessor();

                bool IsValid = cr.validateCustomerDetails(age, employmentType, monthlyIncome, dues, creditScore, defaults);
                if (IsValid)
                {
                    int limit = cr.calculateCreditLimit(monthlyIncome, dues, creditScore, defaults);
                    
                    Console.WriteLine($"Customer Name: {name}");
                    Console.WriteLine($"Approved Credit Limit: ₹{limit}");
                }
            }
            catch (InvalidCreditDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Input.");
            }
        
        
        }
    }
}