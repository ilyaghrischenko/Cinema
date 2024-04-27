namespace DataBase.DbModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

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