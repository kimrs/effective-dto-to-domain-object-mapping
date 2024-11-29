
namespace Functional.Operations;

public static partial class Extensions
{
	public static Result<TR> Then<T, TR>(
		this Result<T> result,
		Func<T, Result<TR>> f
	) => result switch
	{
		Completional<T> c => f(c.Value),
		Validational<T> v => v.Failures,
		Exceptional<T> e => e.Exception,
		_ => new ArgumentOutOfRangeException(nameof(result))
	};
	
	public static async Task<Result<TR>> Then<T, TR>(
		this Result<T> result,
		Func<T, Task<Result<TR>>> f
	) => result switch
	{
		Completional<T> c => await f(c.Value),
		Validational<T> v => v.Failures,
		Exceptional<T> e => e.Exception,
		_ => new ArgumentOutOfRangeException(nameof(result))
	};
	
	public static async Task<Result<TR>> Then<T, TR>(
		this Task<Result<T>> t,
		Func<T, Task<Result<TR>>> f)
	{
		var r = await t;
		return await r.Then(f);
	}

	public static async Task<Result<TR>> Then<T, TR>(
		this Task<Result<T>> t,
		Func<T, Result<TR>> f)
	{
		var r = await t;
		return r.Then(f);
	}

	

	public static Task<Result<TR>> BindAsync<T, TR>(
		this Result<T> result,
		Func<T, Task<Result<TR>>> f
	) => result switch
	{
		Completional<T> c => f(c.Value),
		Validational<T> v => ToTask<TR>(v.Failures),
		Exceptional<T> e => ToTask<TR>(e.Exception),
		_ => ToTask<TR>(new ArgumentOutOfRangeException(nameof(result)))
	};

	private static Task<Result<T>> ToTask<T>(
		this Result<T> result
	) => Task.FromResult(result);
}