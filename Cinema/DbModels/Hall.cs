using static System.Console;

namespace Cinema.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public uint Number { get; set; }
        public uint Capacity { get; set; }

        public Hall() { }
        public Hall(uint number, uint capacity)
        {
            Number = number;
            Capacity = capacity;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Number: {Number}, Capacity: {Capacity}";
        }
    }
}
