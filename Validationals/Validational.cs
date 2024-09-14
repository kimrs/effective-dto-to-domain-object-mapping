using FluentValidation.Results;

namespace Validationals;

public class Validational<T>
{
    public IReadOnlyList<ValidationFailure> Failures { get; }

    public T? Value { get; }

    public bool IsValid { get; }

    private Validational(IReadOnlyList<ValidationFailure> failures)
    {
        Failures = failures;
        Value = default;
        IsValid = false;
    }

    private Validational(T value)
    {
        Failures = [];
        Value = value;
        IsValid = true;
    }

    public override string ToString()
        => IsValid
            ? $"{Value}"
            : string.Join(", ", Failures.Select(x => x.ErrorMessage));

    public static implicit operator Validational<T>(ValidationFailure validationFailure) => new ([validationFailure]);
    public static implicit operator Validational<T>(List<ValidationFailure> validationFailure) => new (validationFailure);
    public static implicit operator Validational<T>(T value) => new (value);
}
