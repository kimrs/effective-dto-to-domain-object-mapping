﻿namespace Functional.Operations;

public static partial class Extensions
{
    // public static TR Match<T, TR>(
    //     this Optional<T> optional,
    //     Func<Optional<TR>> failed,
    //     Func<T, TR> success)
    //     => optional switch
    //     {
    //         Completional<T> c => success(c.Value),
    //         Validational<T> v => failed(optional)
    //
    //     };

// public static TR Match<T, TR>(
    //     this (ValidationResult result, T input) validationResult,
    //     Func<ValidationResult, TR> feilet,
    //     Func<T, TR> validerte
    // ) => validationResult.result.IsValid
    //     ? validerte(validationResult.input)
    //     : feilet(validationResult.result);
    //
    // public static TR Match<T, TR>(
    //     this (ValidationResult result, string input) validationResult,
    //     Func<ValidationResult, TR> feilet,
    //     Func<string, TR> validerte
    // ) => validationResult.result.IsValid
    //     ? validerte(validationResult.input)
    //     : feilet(validationResult.result);
    //
    // public static TR Match<TR>(
    //     this ValidationResult validationResult,
    //     Func<ValidationResult, TR> feilet,
    //     Func<TR> validerte
    // ) => validationResult.IsValid
    //     ? validerte()
    //     : feilet(validationResult);
    //
    // public static TR Match<T, TR>(
    //     this Validational<T> validationResult,
    //     Func<IReadOnlyList<ValidationFailure>, TR> feilet,
    //     Func<T, TR> validerte
    // ) => validationResult.IsValid
    //     ? validerte(validationResult.Value!)
    //     : feilet(validationResult.Failures);
}