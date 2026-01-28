namespace HotelBillingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HotelRoom hr1 = new HotelRoom("Deluxe",1999,"Igloo");
            HotelRoom hr2 = new HotelRoom("Suite",1199,"ROhit");
            Console.WriteLine($"Total Bill : {hr1.CalculateTotalBill(10,2019)}");
            Console.WriteLine($"Total Bill : {hr2.CalculateTotalBill(10,2024)}");
        }
    }
}