namespace ECommerceDiscount
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter Discount type (Member/Festival): ");
            string type = Console.ReadLine();

            Console.Write("Enter Bill Amount: ");
            double amount = int.Parse(Console.ReadLine());

            DiscountPolicy policy = null;

            // Runtime polymorphism
            switch (type.ToLower())
            {
                case "member":
                    policy = new MemberDiscount();
                    break;
                case "festival":
                    policy = new FestivalDiscount();
                    break;
                default:
                    Console.WriteLine("Invalid discount type");
                    return;
            }

            double payableAmount = policy.GetFinalAmount(amount);
            Console.WriteLine($"Total Pay amount after discount = {payableAmount}");
        }
    }
}