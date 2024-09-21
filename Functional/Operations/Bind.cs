﻿namespace Functional.Operations;

public static partial class Extensions
{
	public static Optional<TR> Bind<T, TR>(
		this Optional<T> optional,
		Func<T, Optional<TR>> f
	) => optional switch
	{
		Completional<T> c => f(c.Value),
		Validational<T> v => v.Failures,
		Exceptional<T> e => e.Exception,
		_ => new ArgumentOutOfRangeException(nameof(optional))
	};
}