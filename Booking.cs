using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingAppV1
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int FlightNumber { get; set; }

        public Booking(int bookingId, int customerId, int flightNumber)
        {
            BookingId = bookingId;
            CustomerId = customerId;
            FlightNumber = flightNumber;
        }

        public override string ToString()
        {
            return $"{BookingId},{CustomerId},{FlightNumber}";
        }
    }
}
