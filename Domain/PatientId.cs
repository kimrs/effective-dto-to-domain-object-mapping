using FluentValidation;
using Functional;

namespace DrugDispenser.Domain;

public class PatientId
{
	private readonly string _value;
	public static implicit operator string(PatientId o) => o._value;
	public static implicit operator Result<PatientId>(PatientId s) => s.Validate();

	public static Result<PatientId> Create(
		string value
	) => new PatientId(value)
		.Validate();

	public override string ToString() => _value;

	private PatientId(string value)
	{
		_value = value;
	}

	private Result<PatientId> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<PatientId>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<PatientId>
	{
		public Validator()
		{
			RuleFor(x => x._value)
				.NotEmpty()
				.Length(8)
				.Matches("^[0-9]*$")
				.WithName(nameof(PatientId));
		}
	}
}