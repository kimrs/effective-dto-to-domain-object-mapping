namespace Functional;

public class Completional<T> : Result<T>
{
	public T Value { get; }

	private Completional(T value)
	{
		Value = value;
	}

	public static implicit operator Completional<T>(T value)
		=> new (value);
}

public abstract partial class Result<T>
{
	public static implicit operator Result<T>(T value)
		=> (Completional<T>)  value;
}