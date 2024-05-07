using System.Text.RegularExpressions;

namespace DataBase.DbModels
{
    public class Customer
    {
        private string _email;
        private string _phoneNumber;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get => _email;
            set
            {
                if (!value.Contains('@')) throw new Exception("Invalid email value");
                _email = value;
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (Regex.IsMatch(value, @"^\+380\d{9}$")) _phoneNumber = value;
                else throw new Exception("Invalid phone number value");
            }
        }

        public Customer() { }
        public Customer(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"First name: {FirstName}, Last name: {LastName}, Email: {Email}, Phone number: {PhoneNumber}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Customer) return false;
            var other = obj as Customer;
            return ToString() == other?.ToString();
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}