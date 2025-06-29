using System.ComponentModel.DataAnnotations;
using Event_Management.Models;
namespace Event_Management.DTOs.Event
{
    public class CancelEventDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be positive.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        [Range(0, 1, ErrorMessage = "Status must be either Active or Canceled.")]
        public Status Status { get; set; }
    }
}
