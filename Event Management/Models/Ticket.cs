using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } 
        public bool Isvalid { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Attendance")]
        public int AttendanceId { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
