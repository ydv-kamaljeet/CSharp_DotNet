namespace CabFare
{
    public abstract class Cab
    {
        public abstract int CalculateFare(int km);
    }
    public class Mini : Cab
    {
        public override int CalculateFare(int km)
        {
            return km*12;
        }
    }
    public class Sedan : Cab
    {
        public override int CalculateFare(int km)
        {
            return km* 15 + 50;
        }
    }
    public class SUV : Cab
    {
        public override int CalculateFare(int km)
        {
            return km*18 + 100;
        }
    }
}