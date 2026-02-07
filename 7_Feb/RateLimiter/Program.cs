namespace RateLimiter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RateLimit rl = new RateLimit();

            for (int i = 0; i < 15; i++)
            {
                if (i == 7)
                {
                    Thread.Sleep(10000);    //this will pause the program for 10 sec
                }
                rl.AllowRequest();
            }
        }
    }
}