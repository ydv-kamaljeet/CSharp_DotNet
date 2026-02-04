namespace CustomException
{
    public class NumericInput
    {
        public void TakeInput()
        {
            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                        break;
                    else
                        throw new Exception("Enter valid input");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}