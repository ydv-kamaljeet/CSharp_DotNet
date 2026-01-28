using System.ComponentModel;
using System.Reflection.Metadata;

namespace HotelBillingSystem
{
    public interface IRoom
    {
        double CalculateTotalBill(int nightStayed, int joiningYear);
        public int CalculateMembershipYears(int joiningYear)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - joiningYear;
        }

    }


    public class HotelRoom : IRoom
    {
        public string? RoomType { get; set; }
        public double RatePerNight { get; set; }
        public string? GuestName { get; set; }

        public HotelRoom(string roomtype, double rate, string guestname)
        {
            RoomType = roomtype;
            RatePerNight = rate;
            GuestName = guestname;
        }

        public double CalculateTotalBill(int nightStayed, int joiningYear)
        {
            int membership = ((IRoom)this).CalculateMembershipYears(joiningYear);
            double Bill = nightStayed * RatePerNight;
            if (membership >= 3)
            {
                Bill -= Bill*0.1;
            }
            return Math.Round(Bill);
        }
    }
}