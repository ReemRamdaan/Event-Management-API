using System.ComponentModel.DataAnnotations;
using Event_Management.DTOs.Attendance;
using Event_Management.DTOs.Event;

namespace Event_Management.DTOs.Ticket
{
    public class UpdateTicketDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Ticket ID must be positive.")]
        public int Id { get; set; }
       
    }
}
