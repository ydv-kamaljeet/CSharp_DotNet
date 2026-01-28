namespace HeavenHomesProblem
{
    public class program
    {
        public static void Main(string[] args)
        {
            Apartment apartment = new Apartment();
            int.TryParse(Console.ReadLine(), out int NumberOfAparts);

            while (NumberOfAparts-- != 0)
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

                string? apartmentNo = parts[0];   // "A504"
                string? stringRent = parts[1];   // "12000"
                if(double.TryParse(stringRent, out double rent))
                    apartment.AddApartmentDetails(apartmentNo, rent);
            }

            if( double.TryParse(Console.ReadLine(),out double minRent) &&  double.TryParse(Console.ReadLine(),out double maxRent)){
                double Totalrent = apartment.findTotalRentinGivenRange(minRent,maxRent);
                Console.WriteLine($"Total Rent in the range {minRent} - {maxRent} : {Totalrent} USD");
            }
        }
    }
}