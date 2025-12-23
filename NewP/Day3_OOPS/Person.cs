using System;

namespace kamaljeet;
/// <summary>
/// Generailized class : Person
/// </summary>
public class Person
{
/// <summary>
/// Protected constructor to avoid the object creation without parameters to avoid the null value object creation
/// </summary>
    protected Person() { }
/// <summary>
/// Constructor
/// </summary>
/// <param name="id"></param>
/// <param name="age"></param>
/// <param name="name"></param>
    public Person(int id, int age, string name)
    {
        Id = id;
        Age = age;
        Name = name;
    }

    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; } = "";
}

public class Men : Person
{
    public string Game { get; set; } = "";

    public Men(int id, int age, string name, string game)
        : base(id, age, name)
    {
        Game = game;
    }
}

public class Women : Person
{
    public string PlayAndManage { get; set; } = "";

    public Women(int id, int age, string name, string playAndManage)
        : base(id, age, name)
    {
        PlayAndManage = playAndManage;
    }
}
