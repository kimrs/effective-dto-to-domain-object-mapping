using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drug;

public class ItemNumber
{
	private readonly string? _value;
	public static implicit operator string(ItemNumber o) => o._value!;
	public static implicit operator Optional<ItemNumber>(ItemNumber s) => s.Validate();

	public static Optional<ItemNumber> Create(
		string? value
	) => new ItemNumber(value)
		.Validate();

	public override string ToString() => _value!;

	private ItemNumber(string? value)
	{
		_value = value;
	}

	private Optional<ItemNumber> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<ItemNumber>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<ItemNumber>
	{
		public Validator()
		{
			RuleFor(x => x._value)
				.NotEmpty()
				.Length(5)
				.Matches("^[0-9]*$")
				.WithName(nameof(ItemNumber));
		}
	}
}
