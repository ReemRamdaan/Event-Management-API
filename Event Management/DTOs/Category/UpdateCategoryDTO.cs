using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Category
{
    public class UpdateCategoryDTO:AddCategoryDTO
    {
        [Required(ErrorMessage = "ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be positive.")]
        public int Id { get; set; }
    }
}
