namespace Functional;

public class Exceptional<T> : Optional<T>
{
	public override bool IsValid => false;
	public Exception Exception { get; }

	private Exceptional(Exception exception)
	{
		Exception = exception;
	}

	public static implicit operator Exceptional<T>(Exception exception) => new(exception);
}