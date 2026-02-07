class Program
{
    static void Main()
    {
        var oldCustomer = new Customer
        {
            Name = "John",
            Email = "john@mail.com",
            Age = 30
        };

        var newCustomer = new Customer
        {
            Name = "John",
            Email = "john_new@mail.com",
            Age = 31
        };

        var tracker = new EntityTracker();
        var audits = tracker.TrackChanges(oldCustomer, newCustomer);

        foreach (var a in audits)
        {
            Console.WriteLine(
                $"{a.PropertyName}: {a.OldValue} -> {a.NewValue}");
        }
    }
}
