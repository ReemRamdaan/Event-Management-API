using System.ComponentModel.DataAnnotations;

namespace Event_Management.DTOs.Location
{
    public class AddLocationDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Name should be 80 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Name should be 3 chars")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Address should be 80 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Address should be 3 chars")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Capacity is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be positive.")]
        public int Capacity { get; set; }
    }
}
