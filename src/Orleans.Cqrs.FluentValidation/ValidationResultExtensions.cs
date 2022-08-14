using FluentValidation.Results;

namespace Orleans.Cqrs.FluentValidation;

public static class ValidationResultExtensions
{
    public static IDictionary<string, string[]> ToErrorDictionary(this ValidationResult result)
    {
        return result.Errors
            .GroupBy(k => k.PropertyName)
            .ToDictionary(
                k => k.Key,
                v => v.Select(s => s.ErrorMessage).ToArray()
            );
    }
}
