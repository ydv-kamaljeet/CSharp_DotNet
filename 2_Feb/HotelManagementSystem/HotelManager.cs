using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace HotelBookingSystem
{
    public class HotelManager
    {
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        //  Add room if room number doesn't exist
        public void AddRoom(int roomNumber, string type, double price)
        {
            if (!rooms.ContainsKey(roomNumber))
            {
                rooms[roomNumber] = new Room
                {
                    RoomNumber = roomNumber,
                    RoomType = type,
                    PricePerNight = price,
                    IsAvailable = true
                };
            }
        }

        //  Group available rooms by type
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> groupedRooms = new Dictionary<string, List<Room>>();

            foreach (var room in rooms.Values)
            {
                if (!room.IsAvailable)
                    continue;

                if (!groupedRooms.ContainsKey(room.RoomType))
                {
                    groupedRooms[room.RoomType] = new List<Room>();
                }

                groupedRooms[room.RoomType].Add(room);
            }
            

            return groupedRooms;
        }

        //  Book room if available, calculate total cost
        public bool BookRoom(int roomNumber, int nights)
        {
            if (rooms.ContainsKey(roomNumber) && rooms[roomNumber].IsAvailable)
            {
                Room room = rooms[roomNumber];
                room.IsAvailable = false;

                double totalCost = room.PricePerNight * nights;
                Console.WriteLine($"Room {roomNumber} booked for {nights} nights.");
                Console.WriteLine($"Total Cost: {totalCost}");

                return true;
            }

            return false;
        }

        // 4 Get available rooms within price range
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> result = new List<Room>();

            foreach (var room in rooms.Values)
            {
                if (room.IsAvailable &&
                    room.PricePerNight >= min &&
                    room.PricePerNight <= max)
                {
                    result.Add(room);
                }
            }

            return result;
        }

        public void Checkout(int roomNumber)
        {
            foreach (var room in rooms.Values)
            {
                if(room.RoomNumber == roomNumber)
                {
                    room.IsAvailable = true;
                }
            }
        }
    }
}
