namespace HeavenHomesProblem
{
    public class Apartment
    {
        private Dictionary<string,double> _apartmentDetailsMap;

         public Apartment()
        {
            _apartmentDetailsMap = new Dictionary<string, double>();
        }

        public void AddApartmentDetails(string apartmentNo, double rent)
        {
            _apartmentDetailsMap.Add(apartmentNo, rent);
        }

        public double findTotalRentinGivenRange(double minRent,double maxRent)
        {
            double totalRent = 0;
            foreach (var apartment in _apartmentDetailsMap)
            {
                if (apartment.Value >= minRent && apartment.Value <= maxRent)
                    totalRent+=apartment.Value;
            }
            return totalRent;
        }
    }
}