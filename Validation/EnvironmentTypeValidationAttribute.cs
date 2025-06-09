namespace Ava.Shared.Validation;

public class EnvironmentTypeValidationAttribute : ValidationAttribute
{
    private static readonly HashSet<string> _validValues = new(StringComparer.OrdinalIgnoreCase)
    {
        "PROD","DEV"
    };

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string strValue && _validValues.Contains(strValue))
        {
            return ValidationResult.Success!; // Null-forgiving operator removes the warning
        }
        return new ValidationResult($"Invalid environment type. Allowed values: {string.Join(", ", _validValues)}");
    }
}
