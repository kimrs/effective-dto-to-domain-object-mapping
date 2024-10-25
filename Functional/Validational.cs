using System.Collections.Immutable;
using FluentValidation.Results;

namespace Functional;

public class Validational<T> : Optional<T>
{
    public ImmutableList<ValidationFailure> Failures { get; }

    private Validational(
        IEnumerable<ValidationFailure> failures
    )
    {
        Failures = failures.ToImmutableList();
    }

    public override string ToString()
        => string.Join(", ",
            Failures.Select(x => x.ErrorMessage));

    public static implicit operator Validational<T>(
        List<ValidationFailure> validationFailure)
        => new (validationFailure);
    public static implicit operator Validational<T>(
        ImmutableList<ValidationFailure> validationFailure)
        => new (validationFailure);
    public static implicit operator Validational<T>(
        ValidationFailure validationFailure)
        => new ([validationFailure]);
}

public abstract partial class Optional<T>
{
	public static implicit operator Optional<T>(
        List<ValidationFailure> validationFailures)
        => (Validational<T>) validationFailures;
    
	public static implicit operator Optional<T>(
        ImmutableList<ValidationFailure> validationFailures)
        => (Validational<T>) validationFailures;
    public static implicit operator Optional<T>(
        ValidationFailure validationFailure)
        => (Validational<T>) validationFailure;
}