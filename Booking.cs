using System.Collections.Generic;

namespace FlightBookingAppV1
{
    public class Booking
    {
        public int BookingId { get; private set; }
        public Customer Customer { get; private set; }
        public List<Flight> Flights { get; private set; }

        public Booking(int bookingId, Customer customer, Flight flights)
        {
            BookingId = bookingId;
            Customer = customer;
            Flights = new List<Flight>();
            Flights.Add(flights);
        }
        public Booking(int bookingId, Customer customer, List<Flight> flights)
        {
            BookingId = bookingId;
            Customer = customer;
            Flights =flights;
        }

        public override string ToString()
        {
            string flightDetails = string.Empty;
            int count = 1;
            foreach (var flight in Flights)
            {
                flightDetails += count++ +" : " +flight.GetFlightDetails()+ "\n";
            }

            return $"Booking {BookingId} for Customer {Customer.GetCustomerDetails()}:\n{flightDetails}";
        }

    }
}
