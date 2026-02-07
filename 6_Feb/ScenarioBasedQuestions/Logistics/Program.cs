using System;

namespace Logistics
{
    public class Program
    {
        public static void Main()
        {
            ShipmentDetails shipment = new ShipmentDetails();

            // 1. Input Shipment Code
            Console.Write("Enter Shipment Code: ");
            shipment.ShipmentCode = Console.ReadLine();

            // 2. Validation Phase
            if (!shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }

            // 3. Collect remaining inputs
            Console.Write("Enter Transport Mode (Sea/Air/Land): ");
            shipment.TransportMode = Console.ReadLine();

            Console.Write("Enter Weight: ");
            shipment.Weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Storage Days: ");
            shipment.StorageDays = Convert.ToInt32(Console.ReadLine());

            // 4. Calculate Cost
            double cost = shipment.CalculateTotalCost();
            cost = Math.Round(cost, 2);

            Console.WriteLine($"The total shipping cost is {cost:F2}");
        }
    }
}
