using FluentValidation.Results;

namespace Functional;

public class Validational<T> : Optional<T>
{
    public override bool IsValid => false;
    public List<ValidationFailure> Failures { get; }

    private Validational(List<ValidationFailure> failures)
    {
        Failures = failures;
    }

    public override string ToString()
        => string.Join(", ", Failures.Select(x => x.ErrorMessage));

    public static implicit operator Validational<T>(List<ValidationFailure> validationFailure) => new (validationFailure);
}