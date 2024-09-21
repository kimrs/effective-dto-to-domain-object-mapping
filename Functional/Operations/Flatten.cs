namespace Functional.Operations;

public static partial class Extensions
{
	// public static Validational<List<T>> Flatten<T>(
	// 	this List<Validational<T>> values
	// ) => values.SelectMany(x => x.Failures).ToList() is { Count: > 0 } failures
	// 		? failures
	// 		: values.Select(x => x.Value!).ToList();
	//
	// public static Validational<T[]> Flatten<T>(
	// 	this Validational<T>[] values
	// ) => values.SelectMany(x => x.Failures).ToList() is { Count: > 0 } failures
	// 		? failures
	// 		: values.Select(x => x.Value!).ToArray();
	//
	// public static Validational<T> Flatten<T>(
	// 	this Validational<Validational<T>> vv
	// ) => vv.IsValid
	// 	? vv.Value!
	// 	: vv.Failures.ToList();
}