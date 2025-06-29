using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Organiser
{
    public class AddOrganiserDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Name should be 80 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Name should be 3 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^01(0125)[0-9]{8}$", ErrorMessage = "Maximum Length For the Name should be 80 chars")]
        public string Phone { get; set; }
    }
}
