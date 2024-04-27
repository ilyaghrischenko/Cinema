namespace DataBase.DbModels
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
            return $"Number: {Number}, Capacity: {Capacity}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Hall) return false;
            var other = obj as Hall;
            return ToString() == other?.ToString();
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
