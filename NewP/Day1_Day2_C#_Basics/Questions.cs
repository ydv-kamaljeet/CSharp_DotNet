using System;
namespace kamaljeet;

public class Questions
{
    /// <summary>
    /// Member function to find the quadratic roots of equation
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
     public void FindQuadraticRoots(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            Console.WriteLine($"Roots are real and different: {root1}, {root2}");
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine($"Roots are real and same: {root}");
        }
        else
        {
            Console.WriteLine("Roots are complex and imaginary");
        }
    }



/// <summary>
/// Member function to calculate the electricity bill
/// </summary>
/// <param name="units"></param>
/// <returns></returns>

    public double CalculateElectricityBill(int units)
    {
        double bill;

        if (units <= 199)
            bill = units * 1.20;
        else if (units <= 400)
            bill = units * 1.50;
        else if (units <= 600)
            bill = units * 1.80;
        else
            bill = units * 2.00;

        if (bill > 400)
            bill += bill * 0.15;

        return bill;
    }


/// <summary>
/// Function to check whether the character is vowel or consonant
/// </summary>
/// <param name="ch"></param>
/// <returns></returns>

    public string CheckVowelOrConsonant(char ch)
    {
        ch = char.ToLower(ch);

        switch (ch)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return "Vowel";

            default:
                return "Consonant";
        }
    }


/// <summary>
/// Member function to check the type of triangle
/// </summary>
/// <param name="a"></param>
/// <param name="b"></param>
/// <param name="c"></param>
/// <returns></returns>
     public string GetTriangleType(int a, int b, int c)
    {
        if (a == b && b == c)
            return "Equilateral Triangle";
        else if (a == b || b == c || a == c)
            return "Isosceles Triangle";
        else
            return "Scalene Triangle";
    }


/// <summary>
/// Member function to find the exact location of  point whose X and Y coordinates are given
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <returns></returns>
    public string FindQuadrant(int x, int y)
    {
        if (x > 0 && y > 0) return "First Quadrant";
        else if (x < 0 && y > 0) return "Second Quadrant";
        else if (x < 0 && y < 0) return "Third Quadrant";
        else if (x > 0 && y < 0) return "Fourth Quadrant";
        else if (x == 0 && y == 0) return "Origin";
        else return "On X or Y Axis";
    }



/// <summary>
/// Fcunction to clasify the grades
/// </summary>
/// <param name="grade"></param>
/// <returns></returns>
    public string DescribeGrade(char grade)
    {
        switch (char.ToUpper(grade))
        {
            case 'E': return "Excellent";
            case 'V': return "Very Good";
            case 'G': return "Good";
            case 'A': return "Average";
            case 'F': return "Fail";
            default: return "Invalid Grade";
        }
    }


 
/// <summary>
/// Member function to implement ATM feature
/// </summary>
/// <param name="cardInserted"></param>
/// <param name="pinValid"></param>
/// <param name="balance"></param>
/// <param name="withdrawAmount"></param>
/// <returns></returns>

    public string ATMProcess(bool cardInserted, bool pinValid, double balance, double withdrawAmount)
    {
        if (cardInserted)
        {
            if (pinValid)
            {
                if (balance >= withdrawAmount)
                    return "Transaction Successful";
                else
                    return "Low Balance";
            }
            else
                return "Invalid PIN";
        }
        else
            return "Please Insert Card";
    }


/// <summary>
/// Function to check Profit or Loss
/// </summary>
/// <param name="costPrice">Cost Price of Product</param>
/// <param name="sellingPrice">Selling Price of Product</param>
/// <returns></returns>
    public string ProfitOrLoss(double cP, double sP)
    {
        if (sP > cP)
        {
            double profitPer = ((sP - cP) / cP) * 100;
            return $"Profit of {profitPer:F2}%";
        }
        else if (sP < cP)
        {
            double lossPer = ((cP - sP) / cP) * 100;
            return $"Loss of {lossPer:F2}%";
        }
        else
        {
            return "No Profit No Loss";
        }
    }


/// <summary>
/// Member function to implement Rock Paper Scisors Game
/// </summary>
/// <param name="p1"></param>
/// <param name="p2"></param>
/// <returns></returns>
    public string RockPaperScissors(string p1, string p2)
    {
        if (p1 == p2)
            return "Draw";

        if (p1 == "Rock")
        {
            if (p2 == "Scissors") return "Igloo Wins";
            else return "Shiffuuu Wins";
        }
        else if (p1 == "Paper")
        {
            if (p2 == "Rock") return "Igloo Wins";
            else return "Shiffuuu Wins";
        }
        else if (p1 == "Scissors")
        {
            if (p2 == "Paper") return "Igloo Wins";
            else return "Shiffuuu Wins";
        }

        return "Invalid Input";
    }


/// <summary>
/// Member function to implement a calculator using switch statement
/// </summary>
/// <param name="a">Number 1</param>
/// <param name="b">Number 2</param>
/// <param name="op">Operation</param>
/// <returns></returns>
    public double Calculate(double a, double b, char op)
{
    switch (op)
    {
        case '+': return a + b;
        case '-': return a - b;
        case '*': return a * b;
        case '/': return b != 0 ? a / b : 0;
        default: return 0;
    }
}
}