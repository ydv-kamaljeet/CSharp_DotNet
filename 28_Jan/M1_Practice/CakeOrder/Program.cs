using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CakeOrderProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CakeOrder orders = new CakeOrder();
            int.TryParse(Console.ReadLine(), out int NumberOfOrders);

            while (NumberOfOrders-- != 0)
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

                string? orderPart = parts[0];   // "Order123"
                string? valuePart = parts[1];   // "540"
                if(double.TryParse(valuePart, out double cost))
                    orders.AddOrderDetails(orderPart, cost);
            }

            if(double.TryParse(Console.ReadLine(),out double targetPrice)){
                SortedDictionary<string, double> result = new SortedDictionary<string, double>();   //Will allocate memory only if input is correct.
                result = orders.FindOrdersAboveSpecifiedCost(targetPrice);
                if(result.Count() > 0)
                    orders.Print(result);
                else
                    Console.WriteLine("There is no Cake above this price");
            }

        }

    }
}