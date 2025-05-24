namespace Ava.Shared.Validation;

public class Alpha3ValidationAttribute : ValidationAttribute
{
    private const string Pattern = "^[A-Z]{3}$";
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Consider null valid; use [Required] if you want non-null values.
        if (value == null)
        {
            return ValidationResult.Success;
        }
        
        string strValue = value.ToString() ?? string.Empty;
        if (Regex.IsMatch(strValue, Pattern))
        {
            return ValidationResult.Success;
        }
        
        return new ValidationResult("The field must be exactly 3 alpha characters (A-Z).");
    }
}
