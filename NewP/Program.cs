using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace kamaljeet;

public class Program
{
    public static void Main(string[] args)
    {
        #region Day - 1-2
        // ArmstrongNumber am = new ArmstrongNumber();
        // am.IsArmstrong();
        //creating the object of HeightCategory Class having method to check the height category.
        //HeightCategory hc = new HeightCategory();
        //calling the method to check the category of input height
        //hc.CheckCategory();


        //Creating the object of LeapYear Class having method to check the year is leap year or not.
        // LeapYear lp = new LeapYear();
        //Calling the method 
        //lp.IsLeapYear();

        //Object creation
        //GreatestNumber gn = new GreatestNumber();
        //calling the method to check which number is greatest.
        //gn.WhoIsGreatest();

        // Addmission ad = new Addmission();
        // ad.IsEligible();

        // Fabonaccii fc = new Fabonaccii();
        // fc.Fabo();


        // PrimeOrNot pn = new PrimeOrNot();
        // Console.WriteLine(pn.CheckPrime());
        
        // DiamondPattern dp = new DiamondPattern();
        // dp.PrintDiamond();

        // StrongNumber sn = new StrongNumber();
        // sn.isStrong(45);

        // LargeFactorial lf = new LargeFactorial();
        // lf.FindFactorial();

        // ContinueUsage c = new ContinueUsage();
        // c.UseContinue();

        // Palindrome pal = new Palindrome();
        // Console.WriteLine(pal.IsPalindrome(222));

        // BinaryToInteger BI = new BinaryToInteger();
        // Console.WriteLine(BI.ConvertBinaryToDecimal("100101"));

        // GuessGame gg = new GuessGame();
        // gg.StartGame(45);

        // PascalsTriangle pt = new PascalsTriangle();
        // pt.PrintTriangle();

        // GCD gc = new GCD();
        // Console.WriteLine(gc.Gcd(12,4));
        // Console.WriteLine(gc.LCM(12,4));

        // SumOfDigits sd = new SumOfDigits();
        // Console.WriteLine(sd.DigitalRoot(23));

         Questions q = new Questions();
        // q.FindQuadraticRoots(3,4,2);
        // Console.WriteLine(q.CalculateElectricityBill(43));
        // Console.WriteLine(q.CheckVowelOrConsonant('d'));
        // Console.WriteLine(q.GetTriangleType(4,5,3));
        Console.WriteLine(q.ATMProcess(true,true,2000,500));
        Console.WriteLine(q.Calculate(23,45,'+'));
        Console.WriteLine(q.DescribeGrade('A'));
        Console.WriteLine(q.FindQuadrant(3,9));
        Console.WriteLine(q.ProfitOrLoss(500,700));
        Console.WriteLine(q.RockPaperScissors("Rock","Paper"));
        
        #endregion
        
        #region Day 3
        // Student s1 = new Student("Kamaljeet ",12206320 , "BTech" , "CSE");
        // s1.GetDetails();
        //s1.UpdateDetails();


        // Competition cp = new Competition(101,"Coding");
        // Employee emp1 = new Employee(1,"kamal","Dev",cp);
        // Employee emp2 = new Employee(2,"Shiffu","Dev",cp);
        // Employee emp3 = new Employee(3,"Igloo","Dev",cp);
        // cp.AddParticipant(emp1);
        // cp.AddParticipant(emp3);
        // cp.ShowRegisteredEmp();

        
        // Calling c = new Calling();
        // c.Function1();
        #endregion

        #region Day 4
        
                #region //Handling the exception to invalid argument
            // try{
            // Visitor vs = new Visitor(101,"IGLOO","Want to change my name");
            // vs.ShowDetails();
            // }
            // catch(ArgumentException e)
            // {
            //     Console.WriteLine(e.Message);
            //     return;
            // }
                #endregion
        
            //Addition a1 = new Addition(560,65);

            // Employees emp = new Employees();
            // emp.Id=-1;

            // Associate ass1 = new Associate(101,-1,"");

            // Account ac = new Account(){AccountNumber=100,Name="Igloo"};
            // ac.GetAccountDetails();
            // SalesAccount acc = new SalesAccount(){AccountNumber=100,Name="Igloo",SalesInfo="Yes"};
            // Console.WriteLine(acc.GetSalesAccountDetails());


            // Father c = new Child();
            // Console.WriteLine(c.InterestOn());

        #endregion

    }
    
}

