using CustomExceptionExample;
namespace CallbacksWithDelegates
{    
    class Program
    {
        public static string logs="";//to store the actual error;
        static void Main()
        {
            // var service = new OrderService();

            // // Pass a method as callback
            // service.PlaceOrder("ORD-101", SendEmail);

            // // Pass another method as callback
            // service.PlaceOrder("ORD-102", SendSms);

            try
            {
                int result = Divide(10, 0);
                Console.WriteLine("Result: " + result);
            }
            catch (AppCustomException ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Actual Error : "+logs);  //Printing Actual Error just for our understanding
        }

        static void SendEmail(string msg) => Console.WriteLine("EMAIL: " + msg);
        static void SendSms(string msg) => Console.WriteLine("SMS:   " + msg);
        private static int Divide(int v1, int v2)
        {
            try
            {
                return v1 / v2;
            }
            catch(Exception e)
            {
                logs+=e.Message;    //Adding actual error in log
                throw new AppCustomException(); //throwing custome exception
            }

        }




    }
}