using Event_Management.DTOs.Ticket;

namespace Event_Management.DTOs.Attendance
{
    public class ReadAttendanceWithTicketDTO:ReadAttendanceDTO
    {
        public ReadTicketDTO Ticket { get; set; }

    }
}
