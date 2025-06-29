using Event_Management.DTOs.Attendance;
using Event_Management.DTOs.Event;

namespace Event_Management.DTOs.Ticket
{
    public class ReadTicketDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsValid { get; set; }
        public ReadEventDTO Event { get; set; }
        public ReadAttendanceDTO Attendance { get; set; }

    }
}
