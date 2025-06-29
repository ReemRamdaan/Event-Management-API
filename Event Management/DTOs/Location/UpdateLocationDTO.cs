using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Location
{
    public class UpdateLocationDTO:AddLocationDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Location ID must be positive.")]
        public int Id { get; set; }
    }
}
