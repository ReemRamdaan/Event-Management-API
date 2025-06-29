using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Category
{
    public class AddCategoryDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Name should be 80 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Name should be 3 chars")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(400, ErrorMessage = "Maximum Length For the Description should be 400 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Description should be 3 chars")]
        public string Description { get; set; }
    }
}
