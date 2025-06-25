using System.ComponentModel.DataAnnotations;

namespace BookValidationApp.Models
{
    public class PublishedDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = Convert.ToDateTime(value);
            return dt <= DateTime.Now;
        }
    }
}
