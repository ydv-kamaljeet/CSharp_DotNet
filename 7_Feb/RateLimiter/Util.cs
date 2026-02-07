using Microsoft.VisualBasic;

namespace RateLimiter
{
    public class RateLimit
    {
        public  Queue<DateTime> requests = new();
        public  int limit = 5;
        public  TimeSpan window = TimeSpan.FromSeconds(10);

        public bool AllowRequest()
        {
            DateTime now = DateTime.UtcNow;

            while(requests.Count > 0 && now - requests.Peek() > window)
            {
                requests.Dequeue();
            }   
            if(requests.Count >= limit)
            {
                Console.WriteLine($"Request made at : {now} is blocked. Reason : Requests per 10 second limit is exceed");
                return false;
            }
            requests.Enqueue(now);
            Console.WriteLine($"Request is processed at : {now}");
             return true;
            
        }
    }
}