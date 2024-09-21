namespace Functional.Operations;

public static partial class Extensions
{
	// public static Validational<List<(TR1, TR2)>> Combine<T, TR1, TR2>(
	// 	this IEnumerable<T> v,
	// 	Func<T, Validational<TR1>> f1,
	// 	Func<T, Validational<TR2>> f2
	// ) => v
	// 	.Select(x => Combine(f1(x), f2(x)))
	// 	.ToList()
	// 	.Flatten();
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