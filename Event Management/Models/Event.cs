using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Event_Management.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateOnly Date { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual ICollection<Organiser> Organisers { get; set; }= new List<Organiser> ();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category> ();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance> ();
        public virtual Location Location { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }= new List<Ticket> ();
    }
    public enum Status
    {
        Active,
        Canceled
    }
}
