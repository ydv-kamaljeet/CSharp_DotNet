namespace CustomException
{
    public class Orders
    {
        public void Process()
        {
            int[] OrderId = { 101, -92, 0, 104, 123 };


            foreach (var it in OrderId)
            {
                try
                {
                    if (it <= 0)
                        throw new InvalidOrderIdException();
                    else
                    {
                        Console.WriteLine($"Order Id : {it} is processed.");
                    }
                }
                catch (InvalidOrderIdException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}


public class InvalidOrderIdException : Exception
{
    public override string Message => "Order Id cannt be negative or zero";
}
