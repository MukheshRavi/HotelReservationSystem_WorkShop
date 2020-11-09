using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
   public class HotelRepository
    {
        public List<Hotel> cheapHotels = new List<Hotel>();
        public List<Hotel> hotelsList = new List<Hotel>();
        public int maxRating=0;
        /// <summary>
        /// This method returns cheap hotel with maximum rating
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Hotel GetCheapHotelWithMaxRating(DateTime startDate, DateTime endDate)
        {
            Hotel hotel = new Hotel();
            cheapHotels = hotel.GetCheapHotel(startDate, endDate);
            ///Loop to get maximum rating in cheap Hotels list
            foreach (Hotel h in cheapHotels)
            {
                if (h.rating > maxRating)
                    maxRating = h.rating;
            }
            ///Loop to get hotel with maximum rating
            foreach (Hotel h in cheapHotels)
            {
                if (h.rating == maxRating)
                    return h;
            }
            return null;
        }
        public Hotel GetBestRatingHotel(DateTime startDate, DateTime endDate, Hotel.CustomerType type)
        {
            Hotel hotel = new Hotel();
            hotelsList = hotel.AddHotel(type);
            ///Loop to get maximum rating in Hotels list
            foreach (Hotel h in hotelsList)
            {
                if (h.rating > maxRating)
                    maxRating = h.rating;
            }
            ///Loop to get hotel with maximum rating
            foreach (Hotel h in hotelsList)
            {
                if (h.rating == maxRating)
                {
                    Console.WriteLine(h.hotelName);
                    return h;
                }
            }
            return null;
        }
    }
}
