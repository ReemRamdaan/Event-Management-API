using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Organiser
{
    public class UpdateOrganiserDTO:AddOrganiserDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Organiser ID must be positive.")]
        public int Id { get; set; }
 
    }
}
