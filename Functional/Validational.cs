using FluentValidation.Results;

namespace Functional;

public class Validational<T> : Optional<T>
{
    public List<ValidationFailure> Failures { get; }

    private Validational(List<ValidationFailure> failures)
    {
        Failures = failures;
    }

    public override string ToString()
        => string.Join(", ", Failures.Select(x => x.ErrorMessage));

    public static implicit operator Validational<T>(List<ValidationFailure> validationFailure) => new (validationFailure);
    public static implicit operator Validational<T>(ValidationFailure validationFailure) => new ([validationFailure]);
}

public partial class Optional<T>
{
	public static implicit operator Optional<T>(List<ValidationFailure> validationFailures) => (Validational<T>) validationFailures;
    public static implicit operator Optional<T>(ValidationFailure validationFailure) => (Validational<T>) validationFailure;
}