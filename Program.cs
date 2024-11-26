using System;

namespace FlightBookingAppV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirlineCoordinator coordinator = new AirlineCoordinator();
            int choice = 0;
            do
            {
                
                try
                {
                    Console.Clear();                    
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1: Manage Customers");
                    Console.WriteLine("2: Manage Flights");
                    Console.WriteLine("3: Manage Bookings");
                    Console.WriteLine("4: Exit");

                    if (choice == 9)
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }

                    Console.Write("Enter your choice: ");

                    

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ManageCustomers(coordinator);
                            break;
                        case 2:
                            ManageFlights(coordinator);
                            break;
                        case 3:
                            ManageBookings(coordinator);
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            choice = 9;
                            break;
                    }
                }
                catch (Exception)
                {
                    choice = 9;
                }

            } while (choice != 4);
        }

        static void ManageCustomers(AirlineCoordinator coordinator)
        {
            int choice=0;
            do
            {
               
                
                try
                {
                    Console.Clear();
                    Console.WriteLine("<======================= Customer Menu ========================================> \n");
                    Console.WriteLine("1: Add Customer");
                    Console.WriteLine("2: View Customers");
                    Console.WriteLine("3: Delete Customer");
                    Console.WriteLine("4: Back to Main Menu");
                    if (choice == 9)
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();
                            coordinator.AddCustomer(firstName, lastName, phone);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("<============================Customer List================================> \n");
                            coordinator.ViewCustomers();
                            Console.WriteLine("\n<============================End of Customer List===========================> \n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("Enter Customer ID to delete: ");
                            int customerId = int.Parse(Console.ReadLine());
                            coordinator.DeleteCustomer(customerId);
                            break;
                        case 4:
                            Console.WriteLine("Returning to Main Menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            choice = 9;
                            break;
                    }
                }
                catch (Exception)
                {
                    choice = 9;
                }
            } while (choice != 4);
        }

        static void ManageFlights(AirlineCoordinator coordinator)
        {
            int choice = 0;
            do
            {
               
                try
                {
                    Console.Clear();
                    Console.WriteLine("Flight Menu");
                    Console.WriteLine("1: Add Flight");
                    Console.WriteLine("2: View Flights");
                    Console.WriteLine("3: Delete Flight");
                    Console.WriteLine("4: Back to Main Menu");
                    if (choice == 9)
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Flight Number: ");
                            string flightNumber = Console.ReadLine();
                            Console.Write("Enter Origin: ");
                            string origin = Console.ReadLine();
                            Console.Write("Enter Destination: ");
                            string destination = Console.ReadLine();
                            Console.Write("Enter Max Seats: ");
                            int maxSeats = int.Parse(Console.ReadLine());
                            coordinator.AddFlight(flightNumber, origin, destination, maxSeats);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("<============================Flight List================================> \n");

                            coordinator.ViewFlights();

                            Console.WriteLine("\n<============================End of Flight List===========================> \n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Write("Enter Flight Number to delete: ");
                            flightNumber = Console.ReadLine();
                            coordinator.DeleteFlight(flightNumber);
                            break;
                        case 4:
                            Console.WriteLine("Returning to Main Menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            choice=9;
                            break;
                    }
                }
                catch (Exception)
                {
                    choice = 9;
                }
            } while (choice != 4);
        }

        static void ManageBookings(AirlineCoordinator coordinator)
        {
            int choice=0;
            do
            {   
                Console.Clear();
                Console.WriteLine("Booking Menu");
                Console.WriteLine("1: Add Booking");
                Console.WriteLine("2: View Bookings");
                Console.WriteLine("3: Delete Booking");
                Console.WriteLine("4: Back to Main Menu");
                if (choice == 9)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
                Console.Write("Enter your choice: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Booking ID: ");
                            int bookingId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            var customer = coordinator.GetCustomerById(customerId);
                            if (customer == null)
                            {

                                Console.WriteLine("Customer not found!");
                                break;
                            }

                            Console.Write("Enter the flight Numer: ");
                            string flightNumber = Console.ReadLine();
                            var flight = coordinator.GetFlightByNumber(flightNumber);
                            if (flight != null)
                            {
                                var booking = new Booking(bookingId, customer, flight);
                                coordinator.AddBooking(booking);
                                Console.WriteLine("Booking added successfully!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Flight not found!");
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("<============================Booking List================================> \n");

                            coordinator.ViewBookings();
                            Console.WriteLine("\n<============================End of Booking List===========================> \n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                            break;
                        case 3:
                            Console.Write("Enter Booking ID to delete: ");
                            bookingId = int.Parse(Console.ReadLine());
                            coordinator.DeleteBooking(bookingId);
                            break;
                        case 4:
                            Console.WriteLine("Returning to Main Menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            choice = 9;
                            break;
                    }
                }
                catch (Exception)
                {
                    choice = 9;

                }
                

                
            } while (choice != 4);
        }
    }
}
