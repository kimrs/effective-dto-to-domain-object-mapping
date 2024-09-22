using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Retail;

public class Name
{
	private readonly string? _value;
	public static implicit operator string(Name o) => o._value!;
	public static implicit operator Optional<Name>(Name s) => s.Validate();

	public static Optional<Name> Create(
		string? value
	) => new Name(value)
		.Validate();

	public override string ToString() => _value!;

	private Name(string? value)
	{
		_value = value;
	}

	private Optional<Name> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<Name>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<Name>
	{
		public Validator()
		{
			RuleFor(x => x._value)
				.NotEmpty()
				.MaximumLength(30)
				.MinimumLength(4)
				.Matches("^[A-Å]*$")
				.WithName(nameof(Name));
		}
	}
}
