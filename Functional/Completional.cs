namespace Functional;

public class Completional<T> : Optional<T>
{
	public T Value { get; }

	private Completional(T value)
	{
		Value = value;
	}

	public static implicit operator Completional<T>(T value)
		=> new (value);
}

public abstract partial class Optional<T>
{
	public static implicit operator Optional<T>(T value)
		=> (Completional<T>) value;
}