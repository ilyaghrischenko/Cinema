using static System.Console;

namespace Cinema.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, First name: {FirstName}, Last name: {LastName}, Email: {Email}, Phone number: {PhoneNumber}";
        }
    }
}
