using System.Text.RegularExpressions;

namespace Logistics
{
    public class Shipment
    {
        public string ShipmentCode { get; set; }
        public string TransportMode { get; set; }
        public double Weight { get; set; }
        public int StorageDays { get; set; }
    }

    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            string pattern = "^GC#[0-9]{4}$";
            bool result = Regex.IsMatch(ShipmentCode,pattern);
            return result;
        }

        public double CalculateTotalCost()
        {
            //formula : TotalCost = (Weight \times RatePerKg) + \sqrt{StorageDays}
            double RatePerKg = 0;
            if(TransportMode == "Sea") RatePerKg = 15; 
            else if(TransportMode == "Air") RatePerKg = 50; 
            else if(TransportMode == "Land") RatePerKg = 25; 
            double totalCost = Weight * RatePerKg + Math.Sqrt(StorageDays);
            return totalCost;
        }
    }

    

}