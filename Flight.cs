using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingAppV1
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int MaxSeats { get; set; }

        public Flight(int flightNumber, string origin, string destination, int maxSeats)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            MaxSeats = maxSeats;
        }

        public override string ToString()
        {
            return $"{FlightNumber},{Origin},{Destination},{MaxSeats}";
        }
    }
}
