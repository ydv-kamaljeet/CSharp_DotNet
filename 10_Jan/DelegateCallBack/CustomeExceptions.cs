namespace CustomExceptionExample;

public class AppCustomException : Exception
{
    public override string Message => HandleBase(base.Message); //To hide the actual exception and thrown our own custom exception
                                                                //we can add the actual exception  in logs and display the custom exception to user to maintain security of app.

    private string HandleBase(string sysMessage)
    {
        Console.WriteLine(sysMessage);
        return "Internal Exception";
    }
}



