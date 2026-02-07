class NonGen
{
    public object? Value;

    public void Display()
    {
        Console.WriteLine(Value);
    }
}

class Gen<T>
{
    public T? Value;

    public void Display()
    {
        Console.WriteLine(Value);
    }
}
