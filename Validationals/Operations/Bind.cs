namespace Validationals.Operations;

public static partial class Extensions
{
    public static Validational<TR> Bind<T, TR>(
        this Validational<T> validational,
        Func<T, Validational<TR>> f
    ) => validational.IsValid
        ? f(validational.Value!)
        : validational.Failures.ToList();

    public static Validational<List<TR>> Bind<T,TR>(
        this Validational<List<T>> validational,
        Func<T, Validational<TR>> f
    ) => validational.IsValid
        ? validational.Value!
            .Select(f)
            .ToList()
            .Flatten()
        : validational.Failures.ToList();
	
}