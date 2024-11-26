using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
            }
        }

        public void DeleteCustomer(int customerId)
        {
            customers.RemoveAll(c => c.CustomerId == customerId);
            SaveCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            if (customers.Count == 0)
            {
                LoadCustomers();
            }
            return customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void AddFlight(string flightNumber, string origin, string destination, int maxSeats)
        {
            Flight flight = new Flight(flightNumber.ToUpper(), origin.ToUpper(), destination.ToUpper(), maxSeats);
            flights.Add(flight);
            SaveFlights();
        }

        public void ViewFlights()
        {
            LoadFlights();
            foreach (Flight flight in flights)
            {

                Console.WriteLine(flight.GetFlightDetails());
            }
            if (flights.Count == 0)
            {
                Console.WriteLine("No flights found.");
            }
        }

        public Flight GetFlightByNumber(string flightNumber)
        {
            if (flights.Count == 0)
            {
                LoadFlights();
            }
            return flights.FirstOrDefault(f => f.FlightNumber.Trim() == flightNumber.ToUpper().Trim());
        }

        public void DeleteFlight(string flightNumber)
        {
            flights.RemoveAll(f => f.FlightNumber == flightNumber);
            SaveFlights();
        }
       public bool checkBooking(int bookingId)
        {
            LoadBookings();
            foreach (Booking booking in bookings)
            {
                if (booking.BookingId == bookingId)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddBooking(Booking booking)
        {
            bool bookingExists = checkBooking(booking.BookingId);
            if (bookingExists)
            {
                foreach (Booking b in bookings)
                {
                    if (b.BookingId == booking.BookingId)
                    {
                        b.Flights.AddRange(booking.Flights);
                    }
                }
            }
            else
            {
                bookings.Add(booking);
            }
            
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
                        flights.Add(new Flight(parts[0], parts[1], parts[2], int.Parse(parts[3])));
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
                    string flightsInfo = string.Join("|", booking.Flights.Select(f => f.FlightNumber));
                    writer.WriteLine($"{booking.BookingId},{booking.Customer.CustomerId},{flightsInfo}");
                }
            }
        }

        private void LoadBookings()
        {
            bookings.Clear();
            LoadCustomers();
            LoadFlights();
            if (File.Exists("bookings.txt"))
            {
                using (StreamReader reader = new StreamReader("bookings.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] partsOne = line.Split(',');
                        int bookingId = int.Parse(partsOne[0]);
                        Customer customer = GetCustomerById(int.Parse(partsOne[1]));
                    
                        List<Flight> flightsArray = new List<Flight>();
                        string[] flightNumbers = partsOne[2].Split('|');

                        foreach (string flightNumber in flightNumbers)
                        {
                            Flight flight = GetFlightByNumber(flightNumber);
                            if (flight != null)
                            {
                                flightsArray.Add(flight);
                            }
                        } 
                        bookings.Add(new Booking(bookingId, customer, flightsArray));
                    }
                }
            }
        }
    }
}
