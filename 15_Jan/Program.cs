using System.Collections;
using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Jan_15;


public class Program
{
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>(); //string : Item Detail , Long Sold count
    public static List<Movie> MovieList = new List<Movie>();    //List of Movie class Type { Question 2 }

    public static List<int> NumbersList = new List<int>();  //List of Marks of student per subject {Question 3}

    public static ArrayList MemberList = new ArrayList();   //ArrayList of Meditation Yoga Members 
    public static void Main(string[] args)
    {
        bool Question1 = false;
        bool Question2 = false;
        bool Question3 = false;
        bool Question4 = true;
        bool Question5 = false;
        bool Question6 = true;
        bool Question7 = false;
        if (Question1)
        {
            FeedData();
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();
            int targetCount = 9000;
            //Finding the ItemDetail by sold count
            foreach (var item in itemDetails)
            {
                if (item.Value == targetCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            //Check for empty dictionary
            if (result.Count() == 0)
                Console.WriteLine("Invalid Sold count");
            else
                PrintResult(result);  //Printing the result dictionary

        }

        if (Question2)
        {
            AddMovie("SpiderMan1, Tom Holland, Action, 5");
            AddMovie("SpiderMan2, Tom Holland, Romantic, 4");
            AddMovie("SpiderMan3, Tom Holland, Action, 4");

            var MovieBygenre = ViewMovieDetailsByGenre("action");
            if (MovieBygenre.Count() == 0)
                Console.WriteLine("No Movie Found in this Genre");
            else
            {
                PrintMovies(MovieBygenre);
            }

            //View  Movies by Ratings :
            Console.WriteLine("Movies in Ascending order by Ratings");
            PrintMovies(ViewMovieByRatings());
        }

        if (Question3)
        {
            AddNumber(76);
            AddNumber(69);
            AddNumber(90);
            AddNumber(83);
            double gpa = GetGPAScored();
            Console.WriteLine($"GPA Scored : {gpa}");
            Console.WriteLine($"Grade : {GetGradeScored(gpa)}");
        }

        if (Question4)
        {
            //Adding members
            AddYogaMember(101, 23, 84, 1.71, "Weight Gain");
            AddYogaMember(104, 21, 90, 1.56, "Weight loss");
            PrintMember();

            //Calculating BMI of a particular member having Id =101
            double bmi = CalculateBMI(101);
            if (bmi == 0)
                Console.WriteLine("There is no such Id in Database");
            else
                Console.WriteLine("BMI calculated.");
            PrintMember();

            //Calculating fee of a particular member having ID = 104;
            int fee = CalculateYogaFee(104);
            if (fee == -1)
                Console.WriteLine("No such member is present");
            else
                Console.WriteLine($"Total Payable Fee : {fee}");
        }

        if (Question5)
        {
            try
            {
                ECommerceShop obj = MakePayment("Kamal", 7000, 54000);
                Console.WriteLine($"{obj.Name} Object Created");
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        if (Question6)
        {
            try
            {
                User user = ValidateUSer("Kamaljeet", "Pw@123", "Pw@123","972977834");      //Woth try-catch : if exception caught, only try block will stop, rest program will run smoothly. 
                Console.WriteLine($"Object created for {user.Name}");
            }
            catch (PasswordMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(InvalidNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        if (Question7)
        {
            try
            {
                EstimateDetails obj = ValidateConstructionEstimation(5404, 23450);
                Console.WriteLine("Construction Estimation Approved");
            }
            catch (ConstructionEstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    #region Question 1 Helper Function
    public static void FeedData()
    {
        itemDetails.Add("Laptop", 1000);
        itemDetails.Add("Mobile", 7000);
        itemDetails.Add("Watch", 7000);
        itemDetails.Add("Pen", 15000);
        itemDetails.Add("Tablet", 4500);
    }

    public static void PrintResult(SortedDictionary<string, long> result)
    {
        foreach (var item in result)
        {
            Console.WriteLine($"Item : {item.Key} | Sold Count : {item.Value}");
        }
    }
    #endregion

    #region Question 2 Helper Function
    public static void AddMovie(string MovieDetails)
    {
        List<string> items = MovieDetails
            .Split(',')
            .Select(x => x.Trim())
            .ToList();
        MovieList.Add(new Movie(items[0], items[1], items[2], int.Parse(items[3])));
    }

    public static List<Movie> ViewMovieDetailsByGenre(string genre)
    {
        List<Movie> result = new List<Movie>();
        foreach (var movie in MovieList)
        {
            if (movie.Genre.Trim().Equals(genre.Trim(), StringComparison.OrdinalIgnoreCase))
                result.Add(movie);
        }

        return result;
    }
    public static List<Movie> ViewMovieByRatings()
    {
        List<Movie> result = MovieList.OrderBy(m => m.Ratings).ToList();
        return result;
    }

    public static void PrintMovies(List<Movie> movies)
    {
        foreach (var movie in movies)
        {
            Console.WriteLine($"Movie Name : {movie.Title}  | Movie Artist : {movie.Artist}  | Genre : {movie.Genre}  | Rating : {movie.Ratings}");
        }
    }

    #endregion

    #region Question 3 Helper Functions
    public static void AddNumber(int number)
    {
        NumbersList.Add(number);
    }

    public static double GetGPAScored()
    {
        double GPA = 0;
        int total = 0;
        foreach (var sub in NumbersList)
        {
            total = total + (sub * 3);
        }
        if (NumbersList.Count() == 0)
            return -1;
        else
            GPA = (double)total / (NumbersList.Count() * 3);

        return GPA / 10;
    }

    public static char GetGradeScored(double gpa)
    {
        // Invalid GPA check
        if (gpa < 5 || gpa > 10)
        {
            return '\0';   // null character
        }

        if (gpa == 10)
            return 'S';
        else if (gpa >= 9 && gpa < 10)
            return 'A';
        else if (gpa >= 8 && gpa < 9)
            return 'B';
        else if (gpa >= 7 && gpa < 8)
            return 'C';
        else if (gpa >= 6 && gpa < 7)
            return 'D';
        else // gpa >= 5 && gpa < 6
            return 'E';
    }
    #endregion

    #region Question 4 Helper Fucntion
    public static void AddYogaMember(int id, int age, double wg, double hg, string goal)
    {
        MemberList.Add(new MeditationCentre(id, age, wg, hg, goal));
    }

    public static void PrintMember()
    {
        foreach (MeditationCentre member in MemberList)
        {
            Console.WriteLine($"Member Id : {member.Id} | Goal : {member.Goal}  | BMI : {member.BMI}");
        }
    }
    public static double CalculateBMI(int id)
    {
        double bmi = 0;
        foreach (MeditationCentre member in MemberList)
        {
            if (member.Id == id)
            {
                bmi = member.Weight / (member.Height * member.Height);
                member.BMI = bmi;
            }
        }
        return bmi;
    }

    public static int CalculateYogaFee(int id)
    {
        int fees=-1;
        //bool found=false;
        foreach (MeditationCentre member in MemberList)
        {
            if (member.Id == id)
            {
                double bmi = member.Weight / (member.Height * member.Height);
                if (member.Goal.Trim().Equals("Weight Loss".Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    //condtions
                    if (bmi >= 25 && bmi < 30)
                        fees = 2000;
                    else if (bmi >= 30 && bmi < 35)
                        fees= 2500;
                    else if (bmi >= 35)
                        fees= 3000;
                }
                else if (member.Goal.Trim().Equals("Weight Gain".Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    //condition
                    fees= 2500;
                }
                //found=true;
            }
        }
        
        return fees;
       
    }
    #endregion

    #region Question 5 Helper Function
    public static ECommerceShop MakePayment(string name, double balance, double amount)
    {
        if (balance < amount)
            throw new InsufficientWalletBalanceException();
        else
        {
            return new ECommerceShop(name, balance, amount);
        }
    }
    #endregion

    #region Question 6 Helper Function
    public static User ValidateUSer(string name, string pw, string cpw,string number)
    {
        if (cpw != pw)
            throw new PasswordMismatchException();
        if(number.Length<10)
            throw new InvalidNumberException();
        else
            return new User(name, pw, cpw,number);
    }
    #endregion

    #region  Question 7 Helper Function
    public static EstimateDetails ValidateConstructionEstimation(float constArea, float siteArea)
    {
        if (constArea > siteArea)
            throw new ConstructionEstimateException();
        else
            return new EstimateDetails(constArea, siteArea);
    }
    #endregion



}

