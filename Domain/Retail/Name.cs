using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Retail;

public class Name
{
	private readonly string _value;

	public static Optional<Name> Create(
		string value
	)
	{
		var result = new Validator().Validate(value);
		return result.IsValid
			?  new Name(value)
			: result.Errors;
	}

	private Name(string value)
	{
		_value = value;
	}

	private class Validator
		: AbstractValidator<string>
	{
		public Validator()
		{
			RuleFor(x => x)
				.NotEmpty()
				.MaximumLength(30)
				.MinimumLength(4)
				.Matches("^[A-Å]*$")
				.WithName(nameof(Name));
		}
	}
}
