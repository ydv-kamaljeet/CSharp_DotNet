namespace CabFare
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter cab type (Mini/Sedan/SUV): ");
            string type = Console.ReadLine();

            Console.Write("Enter kilometers: ");
            int km = int.Parse(Console.ReadLine());

            Cab cab = null;

            // Runtime polymorphism
            switch (type.ToLower())
            {
                case "mini":
                    cab = new Mini();
                    break;
                case "sedan":
                    cab = new Sedan();
                    break;
                case "suv":
                    cab = new SUV();
                    break;
                default:
                    Console.WriteLine("Invalid cab type");
                    return;
            }

            int fare = cab.CalculateFare(km);
            Console.WriteLine($"Total Fare = {fare}");
        }
    }
}