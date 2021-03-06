﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string hotelName;
        public int weekDayRate;
        public int weekEndRate;
        public int rating;
        public int totalFare;
        public List<Hotel> hotelsList = new List<Hotel>();
        public enum CustomerType
        {
            REGULAR_CUSTOMER, REWARD_CUSTOMER
        }
        public Hotel() { }
        public Hotel(CustomerType type, string name)
        {
            this.hotelName = name;
            switch (type)
            {
                case CustomerType.REGULAR_CUSTOMER:

                    if (name == "Lakewood")
                    {
                        weekDayRate = 110;
                        weekEndRate = 90;
                        rating = 3;
                    }

                    if (name == "Bridgewood")
                    {
                        weekDayRate = 150;
                        weekEndRate = 50;
                        rating = 4;
                    }

                    if (name == "Ridgewood")
                    {
                        weekDayRate = 220;
                        weekEndRate = 150;
                        rating = 5;
                    }
                    break;
                case CustomerType.REWARD_CUSTOMER:

                    if (name == "Lakewood")
                    {
                        weekDayRate = 80;
                        weekEndRate = 80;
                        rating = 3;
                    }

                    if (name == "Bridgewood")
                    {
                        weekDayRate = 110;
                        weekEndRate = 50;
                        rating = 4;
                    }

                    if (name == "Ridgewood")
                    {
                        weekDayRate = 100;
                        weekEndRate = 40;
                        rating = 5;
                    }
                    break;
                default:
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "INVALID CUSTOMER TYPE");
            }
        }
        /// <summary>
        /// This method adds Hotels to the Hotelslist
        /// </summary>
        public List<Hotel> AddHotel(CustomerType type)
        {
            hotelsList.Add(new Hotel(type,"Lakewood"));
            hotelsList.Add(new Hotel(type,"Bridgewood"));
            hotelsList.Add(new Hotel(type,"Ridgewood"));
            return hotelsList;
        }
        /// <summary>
        /// This method displays Hotels with their names and rates for single day 
        /// </summary>
        public void DisplayHotels()
        {
            AddHotel(CustomerType.REGULAR_CUSTOMER);
            AddHotel(CustomerType.REWARD_CUSTOMER);
            Console.WriteLine("HotelName  WeekDayRate  WeekEndRate   Rating");
            foreach (Hotel hotel in hotelsList)
            {
                Console.WriteLine(hotel.hotelName + "   " + hotel.weekDayRate+"   "+hotel.weekEndRate+"   "+hotel.rating);
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
            AddHotel(CustomerType.REGULAR_CUSTOMER);
            List<int> fareList = new List<int>();
            DateTime start = startDate;
            // Continue loop till all the dates are covered
            foreach (Hotel hotel in hotelsList)
            {
                startDate = start;
                totalFare = 0;
                ///calculating total fare for all hotels in HotelsList
                while (startDate != endDate.AddDays(1))
                {
                    if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                        totalFare += hotel.weekEndRate;
                    else
                        totalFare += hotel.weekDayRate;
                    startDate = startDate.AddDays(1);
                }
                hotel.totalFare = totalFare;
                fareList.Add(totalFare);
            }
            return fareList;
        }
        /// <summary>
        /// This method internally calls GetTotalFare method
        /// returns the name of hotel which has low price for the speific date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<Hotel> GetCheapHotel(DateTime startDate, DateTime endDate)
        {
            // Check for proper start and end date
            if (startDate > endDate)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE_RANGE, "startDate is after endDate");
            }
            List<Hotel> cheapHotels=new List<Hotel>();
            List<int> fareList = new List<int>();
            fareList=GetTotalFare(startDate, endDate);
            fareList.Sort();
            ///checking for the hotel with low cost
            foreach (Hotel hotel in hotelsList)
            {
                if (hotel.totalFare ==fareList[0])
                {
                    Console.WriteLine(hotel.hotelName + " Total rates:" + hotel.totalFare);
                    cheapHotels.Add(hotel);
                }
            }
            return cheapHotels;
        }
        public override bool Equals(object obj)
        {
            // If obj passed is null
            if (obj == null)
                return false;

            // If object passed is of other datatype
            if (!(obj is Hotel))
                return false;

            // Convert the obj into Hotel Details object
            Hotel hotel = ((Hotel)obj);

            // return true if hotel name are same else false
            return this.hotelName == hotel.hotelName && this.weekDayRate == hotel.weekDayRate && this.weekEndRate==hotel.weekEndRate;
        }
    }
}
