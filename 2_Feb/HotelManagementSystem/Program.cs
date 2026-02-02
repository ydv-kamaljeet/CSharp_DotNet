using System;
using System.Buffers;
using System.Collections;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using HotelBookingSystem;

namespace HotelBookingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            HotelManager manager = new HotelManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Hotel Room Booking System =====");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Display Available Rooms Grouped by Type");
                Console.WriteLine("3. Book a Room");
                Console.WriteLine("4. Find Available Rooms by Price Range");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRoom(manager);
                        break;

                    case "2":
                        DisplayRoomsByType(manager);
                        break;

                    case "3":
                        BookRoom(manager);
                        break;

                    case "4":
                        FindRoomsByPriceRange(manager);
                        break;
                    
                    case "5":
                        Console.Write("Enter Room Number :  ");
                        int.TryParse(Console.ReadLine(),out int roomNumber);
                        manager.Checkout(roomNumber);
                        break;

                    case "6":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // ===== Menu Actions =====

        static void AddRoom(HotelManager manager)
        {
            Console.Write("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Room Type (Single / Double / Suite): ");
            string type = Console.ReadLine()!;

            Console.Write("Enter Price Per Night: ");
            double price = double.Parse(Console.ReadLine()!);

            manager.AddRoom(roomNumber, type, price);
            Console.WriteLine("Room added successfully.");
        }

        static void DisplayRoomsByType(HotelManager manager)
        {
            var groupedRooms = manager.GroupRoomsByType();

            if (groupedRooms.Count == 0)
            {
                Console.WriteLine("No available rooms.");
                return;
            }

            foreach (var group in groupedRooms)
            {
                Console.WriteLine($"Room Type: {group.Key}");
                foreach (var room in group.Value)
                {
                    Console.WriteLine($"  Room {room.RoomNumber} - ₹{room.PricePerNight}");
                }
            }
        }

        static void BookRoom(HotelManager manager)
        {
            Console.Write("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Number of Nights: ");
            int nights = int.Parse(Console.ReadLine()!);

            bool success = manager.BookRoom(roomNumber, nights);

            if (!success)
            {
                Console.WriteLine("Room not available or does not exist.");
            }
        }

        static void FindRoomsByPriceRange(HotelManager manager)
        {
            Console.Write("Enter Minimum Price: ");
            double min = double.Parse(Console.ReadLine()!);

            Console.Write("Enter Maximum Price: ");
            double max = double.Parse(Console.ReadLine()!);

            var rooms = manager.GetAvailableRoomsByPriceRange(min, max);

            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms found in this price range.");
                return;
            }

            foreach (var room in rooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} ({room.RoomType}) - ₹{room.PricePerNight}");
            }
        }
    }
}
