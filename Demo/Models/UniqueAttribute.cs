using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return null;
            var context = new AppDbContext();
            var existVal = context.courses.FirstOrDefault(x => x.Name == value);
            Console.WriteLine(existVal);
            if (existVal != null) return new ValidationResult("This value is not unique");
            return ValidationResult.Success;
        }
    }
}
