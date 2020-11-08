using NUnit.Framework;
using HotelReservationSystem;
using System;

namespace TestHotelReservation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// This method checks for the cheapest hotel in a given date range
        /// </summary>
        [Test]
        public void Test1()
        {
            string expected = "Lakewood";
            Hotel hotel = new Hotel();
            hotel.AddHotel();
            string actual = hotel.GetCheapHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 13));
            Assert.AreEqual(expected,actual);
        }
    }
}