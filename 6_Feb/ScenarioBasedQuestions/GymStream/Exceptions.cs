namespace GymStream
{
    public class InvalidTierException : Exception
    {
        public override string Message => "Subscription tier is not supported";
    }
}