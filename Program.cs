using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingAppV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirlineCoordinator coordinator = new AirlineCoordinator();
            int choice;
            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1: Customer");
                Console.WriteLine("2: Flight");
                Console.WriteLine("3: Booking");
                Console.WriteLine("4: Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CustomerMenu(coordinator);
                        break;
                    case 2:
                        FlightMenu(coordinator);
                        break;
                    case 3:
                        BookingMenu(coordinator);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }
        static void CustomerMenu(AirlineCoordinator coordinator)
        {
            int choice=0;
            do
            {
                if (choice == 2)
                {

                    Console.WriteLine("******************************************************************************************************");
                    Console.WriteLine("");
                    Console.WriteLine("1: Customer");
                    Console.WriteLine("4: Back to Main Menu");
                    
                    choice = int.Parse(Console.ReadLine());

                }
                Console.Clear();
                
                Console.WriteLine("Customer Menu");
                Console.WriteLine("1: Add Customer");
                Console.WriteLine("2: View Customers");
                Console.WriteLine("3: Delete Customer");
                Console.WriteLine("4: Back to Main Menu");
                Console.Write("Enter your choice: ");
                 choice = choice!=4? int.Parse(Console.ReadLine()):4;

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phone = Console.ReadLine();
                        coordinator.AddCustomer(firstName, lastName, phone);
                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.Clear();
                        coordinator.ViewCustomers();
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter Customer ID to delete: ");
                        int customerId = int.Parse(Console.ReadLine());
                        coordinator.DeleteCustomer(customerId);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }

        static void FlightMenu(AirlineCoordinator coordinator)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Flight Menu");
                Console.WriteLine("1: Add Flight");
                Console.WriteLine("2: View Flights");
                Console.WriteLine("3: View a Particular Flight");
                Console.WriteLine("4: Delete Flight");
                Console.WriteLine("5: Back to Main Menu");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Flight Number: ");
                        int flightNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Origin: ");
                        string origin = Console.ReadLine();
                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine();
                        Console.Write("Enter Max Seats: ");
                        int maxSeats = int.Parse(Console.ReadLine());
                        coordinator.AddFlight(flightNumber, origin, destination, maxSeats);
                        break;
                    case 2:
                        coordinator.ViewFlights();
                        break;
                    case 3:
                        Console.Write("Enter Flight Number to view: ");
                        flightNumber = int.Parse(Console.ReadLine());
                        coordinator.ViewFlight(flightNumber);
                        break;
                    case 4:
                        Console.Write("Enter Flight Number to delete: ");
                        flightNumber = int.Parse(Console.ReadLine());
                        coordinator.DeleteFlight(flightNumber);
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5);
        }

        static void BookingMenu(AirlineCoordinator coordinator)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Booking Menu");
                Console.WriteLine("1: Add Booking");
                Console.WriteLine("2: View Bookings");
                Console.WriteLine("3: Delete Booking");
                Console.WriteLine("4: Back to Main Menu");
                Console.Write("Enter your choice: ");
                
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Customer ID: ");
                        int customerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Flight Number: ");
                        int flightNumber = int.Parse(Console.ReadLine());
                        coordinator.AddBooking(bookingId, customerId, flightNumber);
                        break;
                    case 2:
                        coordinator.ViewBookings();
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
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
