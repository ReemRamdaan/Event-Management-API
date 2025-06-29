namespace Event_Management.Models
{
    public class Organiser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
        public virtual ICollection<Event> Events { get; set; }=new List<Event>();
    }
}
