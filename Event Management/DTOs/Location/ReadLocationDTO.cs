namespace Event_Management.DTOs.Location
{
    public class ReadLocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        //public EventTest Event {  get; set; }
    }

    public class EventTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}