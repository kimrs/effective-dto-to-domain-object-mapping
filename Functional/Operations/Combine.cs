using System.Collections.Immutable;
using System.Runtime.Intrinsics.Arm;
using FluentValidation.Results;

namespace Functional.Operations;

public static partial class Extensions
{
	public static Optional<(TR1, TR2, TR3)> Combine<T, TR1, TR2, TR3>(
		this T v,
		Func<T, Optional<TR1>> f1,
		Func<T, Optional<TR2>> f2,
		Func<T, Optional<TR3>> f3
	) => Combine(f1(v), f2(v), f3(v));

	private static Optional<(T1, T2, T3)> Combine<T1, T2, T3>(
		Optional<T1> t1,
		Optional<T2> t2,
		Optional<T3> t3
	) => (t1, t2, t3) switch
	{
		 { t1: Completional<T1> c1, t2: Completional<T2> c2, t3: Completional<T3> c3 }  => (c1.Value, c2.Value, c3.Value),
		 { t1: Exceptional<T1> e1} => e1.Exception,
		 { t2: Exceptional<T2> e2} => e2.Exception,
		 { t3: Exceptional<T3> e3} => e3.Exception,
		_ => (t1, t2, t3).ToValidationFailures()
	};

	private static ImmutableList<ValidationFailure> ToValidationFailures<T1, T2, T3>(this (Optional<T1> t1, Optional<T2> t2, Optional<T3> t3) o)
		=> [..o.t1.ToValidationFailures(), ..o.t2.ToValidationFailures(), ..o.t3.ToValidationFailures()];
	public static Optional<(TR1, TR2)> Combine<T, TR1, TR2>(
		this T v,
		Func<T, Optional<TR1>> f1,
		Func<T, Optional<TR2>> f2
	) => Combine(f1(v), f2(v));

	private static Optional<(T1, T2)> Combine<T1, T2>(
		Optional<T1> t1,
		Optional<T2> t2
	) => (t1, t2) switch
	{
		 { t1: Completional<T1> c1, t2: Completional<T2> c2 }  => (c1.Value, c2.Value),
		 { t1: Exceptional<T1> e1} => e1.Exception,
		 { t2: Exceptional<T2> e2} => e2.Exception,
		_ => (t1, t2).ToValidationFailures()
	};

	private static ImmutableList<ValidationFailure> ToValidationFailures<T1, T2>(this (Optional<T1> t1, Optional<T2> t2) o)
		=> [..o.t1.ToValidationFailures(), ..o.t2.ToValidationFailures()];

	private static ImmutableList<ValidationFailure> ToValidationFailures<T>(this Optional<T> o)
		=> o is Validational<T> v
			? v.Failures
			: [];





	//
	// public static Validational<List<(TR1, TR2, TR3)>> Combine<T, TR1, TR2, TR3>(
	// 	this IEnumerable<T> v,
	// 	Func<T, Validational<TR1>> f1,
	// 	Func<T, Validational<TR2>> f2,
	// 	Func<T, Validational<TR3>> f3
	// ) => v
	// 	.Select(x => Combine(f1(x), f2(x), f3(x)))
	// 	.ToList()
	// 	.Flatten();
	//
	//    public static Validational<(TR1, TR2)> Combine<T, TR1, TR2>(
	//        this Validational<T> v,
	//        Func<T, Validational<TR1>> f1,
	//        Func<T, Validational<TR2>> f2
	//    ) => Combine(
	//        v.Bind(f1),
	//        v.Bind(f2)
	//    );
	//
	//    private static Validational<(TR1, TR2, TR3)> Combine<T, TR1, TR2, TR3>(
	//        this Validational<T> v,
	//        Func<T, Validational<TR1>> f1,
	//        Func<T, Validational<TR2>> f2,
	//        Func<T, Validational<TR3>> f3
	//    ) => Combine(
	//        v.Bind(f1),
	//        v.Bind(f2),
	//        v.Bind(f3)
	//    );
	//
	//    public static Validational<(TR1, TR2, TR3, TR4, TR5)> Combine<T, TR1, TR2, TR3, TR4, TR5>(
	//        this Validational<T> v,
	//        Func<T, Validational<TR1>> f1,
	//        Func<T, Validational<TR2>> f2,
	//        Func<T, Validational<TR3>> f3,
	//        Func<T, Validational<TR4>> f4,
	//        Func<T, Validational<TR5>> f5
	//    ) => Combine(
	//        v.Bind(f1),
	//        v.Bind(f2),
	//        v.Bind(f3),
	//        v.Bind(f4),
	//        v.Bind(f5)
	//    );
	//
	// private static Validational<(T1, T2)> Combine<T1, T2>(
	// 	Validational<T1> t1, Validational<T2> t2)
	// 	=> (List<ValidationFailure>)[..t1.Failures, ..t2.Failures] is {Count: > 0} failures
	// 	? failures
	// 	: (t1.Value!, t2.Value!);
	//
	// public static Validational<(T1, T2, T3)> Combine<T1, T2, T3>(
	// 	Validational<T1> t1, Validational<T2> t2, Validational<T3> t3)
	// 	=> (List<ValidationFailure>)[..t1.Failures, ..t2.Failures, ..t3.Failures] is {Count: > 0} failures
	// 	? failures
	// 	: (t1.Value!, t2.Value!, t3.Value!);
	//
	// private static Validational<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(
	// 	Validational<T1> t1,
	// 	Validational<T2> t2,
	// 	Validational<T3> t3,
	// 	Validational<T4> t4,
	// 	Validational<T5> t5
	// ) => (List<ValidationFailure>)[
	// 	..t1.Failures,
	// 	..t2.Failures,
	// 	..t3.Failures,
	// 	..t4.Failures,
	// 	..t5.Failures
	// ] is {Count: > 0} failures
	// 	? failures
	// 	: (t1.Value!, t2.Value!, t3.Value!, t4.Value!, t5.Value!);
	//
	//    public static Validational<TR> Combine<T1, T2, TR>(
	//     this Validational<T1> v1,
	//     Validational<T2> v2,
	//     Func<T1, T2, Validational<TR>> f)
	//     => v1.IsValid && v2.IsValid
	// 	    ? f(v1.Value!, v2.Value!)
	// 	    : (List<ValidationFailure>) [..v1.Failures, ..v2.Failures];
	//    
	//    public static Task<Validational<TR>> CombineAsync<T1, T2, TR>(
	//     this Validational<T1> v1,
	//     Validational<T2> v2,
	//     Func<T1, T2, Task<Validational<TR>>> f)
	//     => v1.IsValid && v2.IsValid
	// 	    ? f(v1.Value!, v2.Value!)
	// 	    : Task.FromResult((Validational<TR>) (List<ValidationFailure>) [..v1.Failures, ..v2.Failures]);
	//
	//    public static Task<Validational<TR>> CombineAsync<T, TR>(
	//     this Validational<T> v,
	//     Func<T, Task<Validational<TR>>> f)
	//     => v.IsValid
	// 	    ? f(v.Value!)
	// 	    : Task.FromResult((Validational<TR>)v.Failures.ToList());
}