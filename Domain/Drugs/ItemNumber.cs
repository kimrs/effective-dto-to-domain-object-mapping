using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drugs;

public class ItemNumber : IFormattable
{
	private readonly string _value;
	public static implicit operator string(ItemNumber o) => o._value;
	public static implicit operator Optional<ItemNumber>(ItemNumber s) => (Completional<ItemNumber>)s;

	public static Optional<ItemNumber> Create(
		string value
	)
	{
		var r = new Validator().Validate(value);
		return r.IsValid
			? (Completional<ItemNumber>) new ItemNumber(value)
			: r.Errors;
	}

	public override string ToString() => _value;

	public string ToString(string? format, IFormatProvider? formatProvider)
		=> format switch
		{
			"M" => $"{{{_value}}}",
			_ => _value
		};

	private ItemNumber(string value)
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
				.Length(5)
				.Matches("^[0-9]*$")
				.WithName(nameof(ItemNumber));
		}
	}
}
