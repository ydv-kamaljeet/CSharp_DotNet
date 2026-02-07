namespace MoneyTransaction
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new MoneyTransferService();

            var result = service.Transfer("A123", "B456", 1000);

            Console.WriteLine(result.Message);
        }
    }
}