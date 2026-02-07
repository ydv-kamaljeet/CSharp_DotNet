namespace CommandPattern
{
    //Implementing on this cart
    public class Cart
    {
        public List<string> Items = new();
        public decimal Discount = 0;
    }


    
    public class AddItem : ICommand
    {
        public Cart cart;
        public string item;

        public AddItem(Cart cart, string item)
        {
            this.cart = cart;
            this.item = item;
        }

        public void Execute() => cart.Items.Add(item);

        public void Undo() => cart.Items.Remove(item);
    }


    public class RemoveItem : ICommand
    {
        public Cart cart;
        public string item;

        public RemoveItem(Cart cart, string item)
        {
            this.cart = cart;
            this.item = item;
        }

        public void Execute() => cart.Items.Remove(item);

        public void Undo() => cart.Items.Add(item);
    }


    public class ApplyDiscount : ICommand
    {
        public Cart cart;
        public decimal discount;

        public ApplyDiscount(Cart cart, decimal discount)
        {
            this.cart = cart;
            this.discount = discount;
        }

        public void Execute() => cart.Discount += discount;

        public void Undo() => cart.Discount -= discount;
    }


    public class CommandManager
    {
        public Stack<ICommand> undo = new();
        public Stack<ICommand> redo = new();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undo.Push(cmd);
            redo.Clear();
        }

        public void Undo()
        {
            if (undo.Count == 0) return;

            var cmd = undo.Pop();
            cmd.Undo();
            redo.Push(cmd);
        }

        public void Redo()
        {
            if (redo.Count == 0) return;

            var cmd = redo.Pop();
            cmd.Execute();
            undo.Push(cmd);

        }
    }

}