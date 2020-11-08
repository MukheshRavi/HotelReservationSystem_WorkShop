using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            Hotel hotel = new Hotel();
            hotel.GetCheapHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));
        }
    }
}
