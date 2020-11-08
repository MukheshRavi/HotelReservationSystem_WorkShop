using NUnit.Framework;
using HotelReservationSystem;
using System;
using System.Collections.Generic;

namespace TestHotelReservation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            List<Hotel> cheapHotels = new List<Hotel>();


        }
        /// <summary>
        /// This method checks for the cheapest hotel in a given date range
        /// </summary>
        [Test]
        public void GetCheapHotelGivenNormalRate()
        {
            List<Hotel> expected = new List<Hotel>();
            List<Hotel> actual = new List<Hotel>();
            expected.Add(new Hotel("Lakewood"));
            Hotel hotel = new Hotel();
            
            actual = hotel.GetCheapHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));
            CollectionAssert.AreEqual(expected,actual);
        }
        /// <summary>
        /// This method checks for cheapest hotel in specific date range
        /// Creates fare using week end rates and week day rates
        /// </summary>
        [Test]
        public void GetCheapHotelGivenWeekDayRateWeekEndRate()
        {
            List<Hotel> expected = new List<Hotel>();
            List<Hotel> actual = new List<Hotel>();
            expected.Add(new Hotel("Lakewood"));
            expected.Add(new Hotel("Bridgewood"));

            Hotel hotel = new Hotel();
            actual = hotel.GetCheapHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// This method gets cheap hotel with maximum Rating
        /// </summary>
        [Test]
        public void GetCheapHotelByRating()
        {
            Hotel expected = new Hotel("Bridgewood");
            HotelRepository hotel = new HotelRepository();
            Hotel actual = hotel.GetCheapHotelWithMaxRating(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// This method gets  hotel with maximum Rating
        /// </summary>
        [Test]
        public void GetBestHotelByRating()
        {
            Hotel expected = new Hotel("Ridgewood");
            HotelRepository hotel = new HotelRepository();
            Hotel actual = hotel.GetBestRatingHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));
            Assert.AreEqual(expected, actual);
        }
    }
}