using System.ComponentModel.DataAnnotations;
using Event_Management.CustomValidation;
using Event_Management.Models;
namespace Event_Management.DTOs.Event
{
    public class AddEventDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Maximum Length For the Name should be 80 chars"), MinLength(3,ErrorMessage="Minimum Length For the Name should be 3 chars")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(400, ErrorMessage = "Maximum Length For the Description should be 400 chars"), MinLength(3, ErrorMessage = "Minimum Length For the Description should be 3 chars")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Date must be today or in the future.")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        [Range(0, 1, ErrorMessage = "Status must be either Active or Canceled.")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Location is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Location ID must be positive.")]
        public int LocationId { get; set; }
    }
}
