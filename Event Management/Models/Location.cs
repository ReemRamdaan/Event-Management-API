namespace Event_Management.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }

        public virtual Event Event { get; set; }
    }
}
