using System.ComponentModel.DataAnnotations;
using Event_Management.Data;
namespace Event_Management.CustomValidation
{
    public class ValidLocationIdAttribute:ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var context = (EventContext)validationContext.GetService(typeof(EventContext));

            if (value is int locationId)
            {
                var exists = context.Locations.Any(l => l.Id == locationId);
                if (exists) return ValidationResult.Success;
            }

            return new ValidationResult("Invalid Location ID.");
        }
    }
}
