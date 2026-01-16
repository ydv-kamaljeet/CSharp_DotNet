namespace Jan_15;

public class User
{
    public string? Name{get;set;}
    public string? Password{get;set;}
    public string? ConfirmPassword{get;set;}
    public string? Number{get;set;}

    public User(string name, string pw, string cpw,string number)
    {
        Name=name;
        Password=pw;
        ConfirmPassword=cpw;
        Number = number;
    }

}

public class PasswordMismatchException : Exception
{
    public override string Message => "Password entered doesnt match." ;
}

public class InvalidNumberException : Exception
{
    public override string Message => "You entered Invalid Mobile Number.";
}