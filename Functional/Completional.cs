namespace Functional;

public class Completional<T> : Optional<T>
{
	public override bool IsValid => true;
	public T Value { get; }

	private Completional(T value)
	{
		Value = value;
	}

	public static implicit operator Completional<T>(T value) => new (value);
}