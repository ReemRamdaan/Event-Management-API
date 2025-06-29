using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Attendance
{
    public class UpdateAttendanceDTO:AddAttendanceDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Attendance ID must be positive.")]
        public int Id {  get; set; }
    }
}
