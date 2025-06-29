using System.ComponentModel.DataAnnotations;
using Event_Management.Models;

namespace Event_Management.DTOs.Event
{
    public class UpdateEventDTO:AddEventDTO
    {
        [Required(ErrorMessage ="ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be positive.")]
        public int Id { get; set; }  
    }
}
