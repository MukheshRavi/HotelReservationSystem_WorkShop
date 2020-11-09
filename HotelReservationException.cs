using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelReservationException:Exception
    {
        public enum ExceptionType
        {
            INVALID_DATE_RANGE,
            INVALID_CUSTOMER_TYPE
        }

        public ExceptionType type;
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
