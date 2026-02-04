using System;
using System.Collections.Generic;

public class CreatorStats
{
    // Stores the name of the content creator
    public string? CreatorName { get; set; }

    // Stores weekly likes data (e.g., Week 1 to Week 4)
    public double[] WeeklyLikes { get; set; }

    // Default constructor
    public CreatorStats()
    {
        WeeklyLikes = Array.Empty<double>();
    }

    // Parameterized constructor to initialize creator data
    public CreatorStats(string? creatorName, double[] weeklyLikes)
    {
        CreatorName = creatorName;
        WeeklyLikes = weeklyLikes;
    }

    // Static list to store all registered creators (acts as shared data store)
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    /// <summary>
    /// Registers a new creator by adding their record to the engagement board
    /// </summary>
    /// <param name="record">CreatorStats object containing creator data</param>
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
        Console.WriteLine("User Registered Successfully");
    }

    /// <summary>
    /// Returns the count of weeks where likes are greater than or equal
    /// to the given threshold for each creator
    /// </summary>
    /// <param name="records">List of creators</param>
    /// <param name="likeThreshold">Minimum likes to qualify as top post</param>
    /// <returns>Dictionary of creator name and count of top-performing weeks</returns>
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        // Iterate through each creator
        foreach (var creator in records)
        {
            int count = 0;

            // Count weeks where likes meet the threshold
            foreach (var val in creator.WeeklyLikes)
            {
                if (val >= likeThreshold)
                {
                    count++;
                }
            }

            // Add creator only if they have at least one top-performing week
            if (count > 0 && creator.CreatorName != null)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates the average likes across all creators and all weeks
    /// </summary>
    /// <returns>Average weekly likes</returns>
    public double CalculateAverageLikes()
    {
        int count = 0;
        double total = 0;

        // Traverse all creators and their weekly likes
        foreach (var creator in EngagementBoard)
        {
            foreach (var val in creator.WeeklyLikes)
            {
                total += val;
                count++;
            }
        }

        // Prevent division by zero
        if (count == 0)
        {
            return 0;
        }

        return total / count;
    }
}

public class Program
{
    public static void Main()
    {
        CreatorStats service = new CreatorStats();
        bool running = true;

        // Menu-driven program
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string creatorName = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    double[] weeklyLikes = new double[4];

                    for (int i = 0; i < 4; i++)
                    {
                        weeklyLikes[i] = double.Parse(Console.ReadLine() ?? "0");
                    }

                    CreatorStats record = new CreatorStats(creatorName, weeklyLikes);
                    service.RegisterCreator(record);

                    // Required output message
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine() ?? "0");

                    Dictionary<string, int> result =
                        service.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                case 3:
                    double average = service.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {average}");
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
