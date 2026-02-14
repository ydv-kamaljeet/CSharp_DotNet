namespace Logistics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShipmentDetails util = new ShipmentDetails();

            Console.WriteLine("Enter Shipment Code : ");
            util.ShipmentCode = Console.ReadLine() ?? "";
            if(!util.ValidateShipmentCode()){
                Console.WriteLine("Invalid Shipment Code");
                return;
            }
            Console.WriteLine("Enter Transport Mode : ");
            util.TransportMode = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Weight : ");
            util.Weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Storage Days : ");
            util.StorageDays = int.Parse(Console.ReadLine());

            Console.WriteLine($"Total Bill : {util.CalculateTotalCost():F2}");
        }   
    }
}