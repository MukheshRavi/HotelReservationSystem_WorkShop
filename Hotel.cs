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
            if(name=="Lakewood") 
                rate = 110;
            if (name == "Bridgewood")
                rate = 160;
            if (name == "Ridgewood")
                rate = 220;
        }
        public void AddHotel()
        {
            hotelsList.Add(new Hotel("Lakewood"));
            hotelsList.Add(new Hotel("Bridgewood"));
            hotelsList.Add(new Hotel("Ridgewood"));
        }
        public void DisplayHotels()
        {
            AddHotel();
            Console.WriteLine("HotelName  Rate");
            foreach(Hotel hotel in hotelsList)
            {
                Console.WriteLine(hotel.hotelName + " " + hotel.rate);
            }

        }

    }
}
