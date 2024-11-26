namespace FlightBookingAppV1
{
    public class Flight
    {
        public string FlightNumber { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public int MaxSeats { get; private set; }

        public Flight(string flightNumber, string origin, string destination, int maxSeats)
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
        public string GetFlightDetails()
        {
            return $" {FlightNumber} - {Origin} to {Destination} ({MaxSeats} seats)";
        }

    }
}
