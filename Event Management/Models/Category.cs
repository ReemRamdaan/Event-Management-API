namespace Event_Management.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Event> Events { get; set; }=new List<Event>();

    }
}
