using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string hotelName;
        public int rate;
        public List<Hotel> hotelsList = new List<Hotel>();
        public Hotel() { }
        public Hotel(string name)
        {
            this.hotelName = name;
            if (name == "Lakewood")
                rate = 110;
            if (name == "Bridgewood")
                rate = 160;
            if (name == "Ridgewood")
                rate = 220;
        }
        /// <summary>
        /// This method adds Hotels to the Hotelslist
        /// </summary>
        public void AddHotel()
        {
            hotelsList.Add(new Hotel("Lakewood"));
            hotelsList.Add(new Hotel("Bridgewood"));
            hotelsList.Add(new Hotel("Ridgewood"));
        }
        /// <summary>
        /// This method displays Hotels with their names and rates for single day 
        /// </summary>
        public void DisplayHotels()
        {
            AddHotel();
            Console.WriteLine("HotelName  Rate");
            foreach (Hotel hotel in hotelsList)
            {
                Console.WriteLine(hotel.hotelName + " " + hotel.rate);
            }

        }
        /// <summary>
        /// This method returns list of total fare for all hotels for a specific date range  
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<int> GetTotalFare(DateTime startDate, DateTime endDate)
        {
            List<int> FareList = new List<int>();
            // Continue loop till all the dates are covered
            foreach (Hotel hotel in hotelsList)
            {
                int totalFare = 0;
                ///calculating total fare for all hotels in HotelsList
                while (startDate != endDate.AddDays(1))
                {
                    totalFare += hotel.rate;
                    startDate = startDate.AddDays(1);
                }
                FareList.Add(totalFare);
            }
            return FareList;

        }
        /// <summary>
        /// This method internally calls GetTotalFare method
        /// returns the name of hotel which has low price for the speific date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string GetCheapHotel(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            List<int> FareList = GetTotalFare(startDate, endDate);
            FareList.Sort();
            ///counting the number of days
            while (startDate != endDate.AddDays(1))
            {
                count += 1;
                startDate = startDate.AddDays(1);
            }
            ///checking for the name of hotel with low cost
            foreach (Hotel hotel in hotelsList)
            {
                if (hotel.rate == FareList[0] / count)
                    Console.WriteLine(hotel.hotelName + " Total rates:" + FareList[0]);
                    return hotel.hotelName;
            }
            return null;
        }
    }
}
