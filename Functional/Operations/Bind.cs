
namespace Functional.Operations;

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

	public static Task<Optional<TR>> BindAsync<T, TR>(
		this Optional<T> optional,
		Func<T, Task<Optional<TR>>> f
	) => optional switch
	{
		Completional<T> c => f(c.Value),
		Validational<T> v => ToTask<TR>(v.Failures),
		Exceptional<T> e => ToTask<TR>(e.Exception),
		_ => ToTask<TR>(new ArgumentOutOfRangeException(nameof(optional)))
	};

	private static Task<Optional<T>> ToTask<T>(
		this Optional<T> optional
	) => Task.FromResult(optional);
}