namespace Functional;

public class Exceptional<T> : Optional<T>
{
	public Exception Exception { get; }

	private Exceptional(Exception exception)
	{
		Exception = exception;
	}

	public static implicit operator Exceptional<T>(
		Exception exception)
		=> new(exception);
}

public abstract partial class Optional<T>
{
	public static implicit operator Optional<T>(
		Exception exception)
		=> (Exceptional<T>) exception;
}
