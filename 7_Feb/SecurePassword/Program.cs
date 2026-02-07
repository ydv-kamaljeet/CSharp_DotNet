class Program
{
    static void Main()
    {
        string password = "MySecret123";

        string hash = PasswordSecurity.HashPassword(password);
        Console.WriteLine("Stored Hash: " + hash);

        bool ok = PasswordSecurity.VerifyPassword("MySecret123", hash);
        Console.WriteLine("Password valid? " + ok);
    }
}
