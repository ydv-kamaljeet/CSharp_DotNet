using System.Text.RegularExpressions;
namespace Logistics
{
    public class Shipment
    {
        public string ShipmentCode {get;set;}
        public string TransportMode{get;set;}
        public double Weight{get;set;}
        public int StorageDays{get;set;}

    }

    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if (string.IsNullOrWhiteSpace(ShipmentCode))
                return false;
            string pattern = @"^GC#[0-9]{4}$";
            return Regex.IsMatch(ShipmentCode,pattern);                
        }


        public double CalculateTotalCost()
        {
            double RatePerKg = 0;
            if(TransportMode == "Air")
            {
                RatePerKg = 50;
            }else if(TransportMode == "Sea")
            {
                RatePerKg = 15;
            }else if(TransportMode== "Land")
            {
                RatePerKg = 25;
            }
            else
            {
                Console.WriteLine("Incorrect Transportation Mode");
                return -1;
            }
            double total = Weight*RatePerKg + Math.Sqrt(StorageDays);
            return total;
        }
    }
}