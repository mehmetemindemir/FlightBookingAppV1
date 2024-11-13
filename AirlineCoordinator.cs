using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingAppV1
{
    internal class AirlineCoordinator
    {
        private List<Customer> customers;
        private List<Flight> flights;
        private List<Booking> bookings;

        public AirlineCoordinator()
        {
            customers = new List<Customer>();
            flights = new List<Flight>();
            bookings = new List<Booking>();
        }

        public void AddCustomer(string firstName, string lastName, string phone)
        {
            int customerId = customers.Count + 1;
            Customer customer = new Customer(customerId, firstName, lastName, phone);
            customers.Add(customer);
            SaveCustomers();
        }

        public void ViewCustomers()
        {
            LoadCustomers();
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public void DeleteCustomer(int customerId)
        {
            customers.RemoveAll(c => c.CustomerId == customerId);
            SaveCustomers();
        }

        public void AddFlight(int flightNumber, string origin, string destination, int maxSeats)
        {
            Flight flight = new Flight(flightNumber, origin, destination, maxSeats);
            flights.Add(flight);
            SaveFlights();
        }

        public void ViewFlights()
        {
            LoadFlights();
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
            }
        }

        public void ViewFlight(int flightNumber)
        {
            LoadFlights();
            Flight flight = flights.Find(f => f.FlightNumber == flightNumber);
            if (flight != null)
            {
                Console.WriteLine(flight);
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        public void DeleteFlight(int flightNumber)
        {
            flights.RemoveAll(f => f.FlightNumber == flightNumber);
            SaveFlights();
        }

        public void AddBooking(int bookingId, int customerId, int flightNumber)
        {
            Booking booking = new Booking(bookingId, customerId, flightNumber);
            bookings.Add(booking);
            SaveBookings();
        }

        public void ViewBookings()
        {
            LoadBookings();
            foreach (Booking booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }

        public void DeleteBooking(int bookingId)
        {
            bookings.RemoveAll(b => b.BookingId == bookingId);
            SaveBookings();
        }

        private void SaveCustomers()
        {
            using (StreamWriter writer = new StreamWriter("customers.txt"))
            {
                foreach (Customer customer in customers)
                {
                    writer.WriteLine(customer.ToString());
                }
            }
        }

        private void LoadCustomers()
        {
            customers.Clear();
            if (File.Exists("customers.txt"))
            {
                using (StreamReader reader = new StreamReader("customers.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        customers.Add(new Customer(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
                    }
                }
            }
        }

        private void SaveFlights()
        {
            using (StreamWriter writer = new StreamWriter("flights.txt"))
            {
                foreach (Flight flight in flights)
                {
                    writer.WriteLine(flight.ToString());
                }
            }
        }

        private void LoadFlights()
        {
            flights.Clear();
            if (File.Exists("flights.txt"))
            {
                using (StreamReader reader = new StreamReader("flights.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        flights.Add(new Flight(int.Parse(parts[0]), parts[1], parts[2], int.Parse(parts[3])));
                    }
                }
            }
        }

        private void SaveBookings()
        {
            using (StreamWriter writer = new StreamWriter("bookings.txt"))
            {
                foreach (Booking booking in bookings)
                {
                    writer.WriteLine(booking.ToString());
                }
            }
        }

        private void LoadBookings()
        {
            bookings.Clear();
            
            if (File.Exists("bookings.txt"))
            {
                using (StreamReader reader = new StreamReader("bookings.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        bookings.Add(new Booking(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])));
                    }
                }
            }
        }
    }
}
