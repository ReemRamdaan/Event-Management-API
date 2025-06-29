using System.ComponentModel.DataAnnotations;

namespace Event_Management.CustomValidation
{
    public class FutureDateAttribute:ValidationAttribute
    {
         public override bool IsValid(object value)
    {
            if (value is DateOnly date)
            {
                return date >= DateOnly.FromDateTime(DateTime.Today);
            }
            return false;
    }
    }
}
