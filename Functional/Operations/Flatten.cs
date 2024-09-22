namespace Functional.Operations;

public static partial class Extensions
{
	public static Optional<List<T>> Flatten<T>(
		this List<Optional<T>> values
	)
	{
		if (values.OfType<Exceptional<T>>().Any())
		{
			return values
				.OfType<Exceptional<T>>()
				.First().Exception;
		}

		if (values.OfType<Validational<T>>().Any())
		{
			return values
				.OfType<Validational<T>>()
				.SelectMany(x => x.Failures).ToList();
		}

		return values
			.OfType<Completional<T>>()
			.Select(x => x.Value)
			.ToList();
	}
}