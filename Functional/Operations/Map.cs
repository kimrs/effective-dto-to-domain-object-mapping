namespace Functional.Operations;

public static partial class Extensions
{
    // public static Validational<TR> Map<T, TR>(
    //     this Validational<T> validational,
    //     Func<T, TR> f
    // ) => validational.IsValid
    //     ? f(validational.Value!)
    //     : validational.Failures.ToList();
    //
    // public static Validational<List<TR>> Map<T, TR>(
    //     this Validational<IEnumerable<T>> validational,
    //     Func<T, TR> f
    // ) => validational.IsValid
    //     ? validational.Value!.Select(f).ToList()
    //     : validational.Failures.ToList();
    //
    // public static async Task<Validational<TR>> MapAsync<T, TR>(
    //     this Validational<Task<T>> v,
    //     Func<T, TR> f
    // ) => v.IsValid
    //     ? f(await v.Value!)
    //     : v.Failures.ToList();
}