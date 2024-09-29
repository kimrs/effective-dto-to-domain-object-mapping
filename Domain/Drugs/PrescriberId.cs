using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drug;

public class PrescriberId
{
	private readonly string? _value;
	public static implicit operator string(PrescriberId o) => o._value!;
	public static implicit operator Optional<PrescriberId>(PrescriberId s) => s.Validate();

	public static Optional<PrescriberId> Create(
		string? value
	) => new PrescriberId(value)
		.Validate();

	public override string ToString() => _value!;

	private PrescriberId(string? value)
	{
		_value = value;
	}

	private Optional<PrescriberId> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<PrescriberId>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<PrescriberId>
	{
		public Validator()
		{
			RuleFor(x => x._value)
				.NotEmpty()
				.Length(9)
				.Matches("^[0-9]*$")
				.WithName(nameof(PrescriberId));
		}
	}
}
