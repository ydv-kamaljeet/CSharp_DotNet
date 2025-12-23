using System;

/// <summary>
/// MenuSystem - Interactive console menu using do-while loop
/// Demonstrates persistent menu system that continues until user chooses to exit
/// Uses switch statement for menu option handling and do-while for continuous operation
/// </summary>
namespace kamaljeet;

    public class MenuSystem
    {
        /// <summary>
        /// Displays an interactive food ordering menu
        /// Continues to show menu until user selects exit option
        /// Demonstrates do-while loop and switch statement usage
        /// </summary>
        public void FoodMenu()
        {
            int num;  // Store user's menu choice

            // Do-while ensures menu is shown at least once
            do
            {
                // Display menu options
                Console.WriteLine("\nPress the number to Order the Food From Briyani House!");
                Console.WriteLine("Press 1 for Chicken Briyani");
                Console.WriteLine("Press 2 for Paneer Briyani");
                Console.WriteLine("Press 3 for Veg Briyani");
                Console.WriteLine("Press 4 for Exiting.....");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();  // Get user input

                // Validate input - check if it's a valid integer
                if (int.TryParse(choice, out num))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;  // Skip to next iteration if input is invalid
                }

                // Process user choice using switch statement
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Chicken Briyani Ordered");
                        break;

                    case 2:
                        Console.WriteLine("Paneer Briyani Ordered");
                        break;

                    case 3:
                        Console.WriteLine("Veg Briyani Ordered");
                        break;

                    case 4:
                        Console.WriteLine("Exiting... Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (num != 4);  // Continue until user chooses to exit (option 4)
        }
 }