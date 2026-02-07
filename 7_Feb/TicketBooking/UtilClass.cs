using System.Collections.Generic;

public class Seat
{
    public int SeatNo { get; set; }
    public bool IsBooked { get; set; }
    public string BookedBy { get; set; }
}

public class TicketService
{
    private readonly Dictionary<int, Seat> seats = new();
    private readonly object lockObj = new object();

    public TicketService()
    {
        for (int i = 1; i <= 10; i++)
        {
            seats[i] = new Seat { SeatNo = i };
        }
    }

    public bool BookSeat(int seatNo, string userId)
    {
        if (!seats.ContainsKey(seatNo))
            return false;

        var seat = seats[seatNo];

        lock (seat)
        {
            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            seat.BookedBy = userId;

            return true;
        }
    }

}
