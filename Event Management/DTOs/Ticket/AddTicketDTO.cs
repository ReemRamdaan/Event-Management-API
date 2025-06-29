using System.ComponentModel.DataAnnotations;
using Event_Management.DTOs.Attendance;
using Event_Management.DTOs.Event;

namespace Event_Management.DTOs.Ticket
{
    public class AddTicketDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Name should be 80 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Name should be 3 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be positive.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "IsValid is Required")]
        [Range(0, 1, ErrorMessage = "IsValid must be either True or False.")]
        public bool IsValid { get; set; }

        [Required(ErrorMessage = "Event Id is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be positive.")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Attendance Id is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Attendance ID must be positive.")]
        public int AttendanceId { get; set; }
    }
}
