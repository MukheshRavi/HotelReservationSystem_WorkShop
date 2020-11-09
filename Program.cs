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
            HotelRepository hotelRepository = new HotelRepository();
            // hotel.GetCheapHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));
            hotel.DisplayHotels();
            hotelRepository.GetBestRatingHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11), Hotel.CustomerType.REGULAR_CUSTOMER);
        }
    }
}
