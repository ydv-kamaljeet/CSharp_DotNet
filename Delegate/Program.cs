namespace DelegateExample
{
    public delegate void MyDelegate();

    public class Program
    {
        public static void Confirmation()
        {
            Console.WriteLine("Enter Confirmation message : ");
            string msg = Console.ReadLine();
            Console.WriteLine("A : " + msg);

        }
        public static void Packed()
        {
            Console.WriteLine("Enter Packaging message : ");
            string msg = Console.ReadLine();
            Console.WriteLine("B : " + msg);
        }
        public static void Delivery()
        {
            Console.WriteLine("Enter Delivery message : ");
            string msg = Console.ReadLine();
            Console.WriteLine("C : " + msg);
        }

        public static void Main(string[] args)
        {
            PrintingCompany pc = new PrintingCompany();

            pc.CustomerChoicePrintMessage = new PrintMessage(Method4);
            pc.CustomerChoicePrintMessage += new PrintMessage(Method5);
            pc.Print("Kamal\n");



            MyDelegate d = Confirmation;
            d += Packed;
            d += Delivery;

            d();

        }

        private static string Method4(string message)
        {
            return "Welcome to Delegate world  " + message;
        }
        private static string Method5(string message)
        {
            return "Welcome to Delegate world 2  " + message;
        }

    }
}