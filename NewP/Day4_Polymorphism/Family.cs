using System;
namespace kamaljeet;

public class Father
{
    public  string InterestOn()
    {
        return "Father like to play cricket";
    }
}
public class Child:Father
{
    public string InterestOn()
    {
        return "child likes to play Mobile Games";
    }
}