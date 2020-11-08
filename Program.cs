using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            Hotel hotel = new Hotel();
            ///Displays all hotels with their names and rates for the day
            hotel.DisplayHotels();
        }
    }
}
