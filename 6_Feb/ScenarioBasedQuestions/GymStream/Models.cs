namespace GymStream
{
    public class Membership
    {
        public string Tier{get;set;}
        public int DurationInMonths{get;set;}
        public double BasePricePerMonth{get;set;}


        public bool ValidateEnrollment()
        {
            if(!Tier.Equals("Basic", StringComparison.OrdinalIgnoreCase)  || !Tier.Equals("Premium", StringComparison.OrdinalIgnoreCase)  || !Tier.Equals("Elite", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidTierException();
            }
            if(DurationInMonths<=0)
                throw new Exception("");
        }

    }
}