namespace CommandPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cart = new Cart();
            var mgr = new CommandManager();

            mgr.Execute(new AddItem(cart, "Laptop"));
            mgr.Execute(new ApplyDiscount(cart, 100));
            mgr.Execute(new AddItem(cart, "phone"));
            Print(cart.Items);      //List will have these 2 items

            mgr.Undo(); // phone will be removed from cart
            Print(cart.Items);

            mgr.Redo(); //phone will be again added to cart
            Print(cart.Items); 

            mgr.Execute(new ApplyDiscount(cart, 50));
            Console.WriteLine($"Discount : {cart.Discount}");
            mgr.Undo(); // discount subtracted
            Console.WriteLine($"Discount after Undo : {cart.Discount}");
        }


    //Printing the items frmo cart
        public static void Print(List<string> items)
        {
            Console.WriteLine( "----- CART -----");
            foreach(var item in items)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
        }
    }
}