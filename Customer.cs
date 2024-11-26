namespace FlightBookingAppV1
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }

        public Customer(int customerId, string firstName, string lastName, string phone)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{CustomerId},{FirstName},{LastName},{Phone}";
        }
        public string GetCustomerDetails()
        {
            return $"{CustomerId} - {FirstName} {LastName} ({Phone})";
        }
    }
}
