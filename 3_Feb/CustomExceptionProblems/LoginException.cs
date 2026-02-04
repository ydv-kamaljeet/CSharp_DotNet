namespace CustomException
{
    public class LoginClass
    {
        public void login()
        {
            int Attempts = 3;
            string password = "abc";
            bool flag = false;
            try
            {
                while (Attempts-- != 0)
                {
                    Console.WriteLine($"Attempt {3 - Attempts } : Enter Password.");
                    string input = Console.ReadLine();
                    if (string.Equals(input, password))
                    {
                        Console.WriteLine("Login success.");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    throw new LimitExceedException();
            }
            catch (LimitExceedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class LimitExceedException : Exception
    {
        public override string Message => "Your login attempt limit exceed. try after some time.";
    }
}