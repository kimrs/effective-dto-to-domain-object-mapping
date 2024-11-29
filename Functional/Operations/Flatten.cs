using System.Collections.Immutable;

namespace Functional.Operations;

public static partial class Extensions
{
	public static Result<List<T>> Flatten<T>(
		this List<Result<T>> values
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
				.SelectMany(x => x.Failures)
				.ToImmutableList();
		}

		return values
			.OfType<Completional<T>>()
			.Select(x => x.Value)
			.ToList();
	}
}