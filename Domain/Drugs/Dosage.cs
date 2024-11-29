using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drugs;

public record Dosage
{
    public string Amount { get; }
    public string Unit { get; }

    public static Result<Dosage> Create(string amount, string unit)
    {
	    Dosage dosage = new(amount, unit);
	    return dosage.Validate();
    }

    private Dosage(string amount, string unit)
    {
	    Amount = amount;
	    Unit = unit;
    }

	private Result<Dosage> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<Dosage>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<Dosage>
	{
		public Validator()
		{
			RuleFor(x => x.Amount)
				.NotEmpty()
				.MinimumLength(1)
				.MaximumLength(3)
				.Matches("^[0-9]*$");

			RuleFor(x => x.Unit)
				.NotEmpty();
		}
	}
}