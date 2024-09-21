using FluentValidation.Results;

namespace Functional;

public abstract class Optional<T>
{
	public abstract bool IsValid { get; }
	
	public static implicit operator Optional<T>(Exception exception) => (Exceptional<T>) exception;
	public static implicit operator Optional<T>(List<ValidationFailure> validationFailures) => (Validational<T>) validationFailures;
    public static implicit operator Optional<T>(T value) => (Completional<T>) value;
}