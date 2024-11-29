using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drugs;

public class PrescriberId
{
	private readonly string? _value;
	public static implicit operator string(PrescriberId o) => o._value!;
	public static implicit operator Result<PrescriberId>(PrescriberId s) => s.Validate();

	public static Result<PrescriberId> Create(
		string? value
	) => new PrescriberId(value)
		.Validate();

	public override string ToString() => _value!;

	private PrescriberId(string? value)
	{
		_value = value;
	}

	private Result<PrescriberId> Validate()
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
