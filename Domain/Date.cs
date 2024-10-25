using FluentValidation;
using Functional;

namespace DrugDispenser.Domain;
    
public class ApprovalDate
{
	private readonly DateTime _value;
	public static implicit operator DateTime(ApprovalDate o) => o._value;
	public static implicit operator Optional<ApprovalDate>(ApprovalDate d) => d.Validate();

	public static Optional<ApprovalDate> Create(
		DateTime value
	) => new ApprovalDate(value)
		.Validate();

	private ApprovalDate(DateTime value)
	{
		_value = value;
	}

	private Optional<ApprovalDate> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<ApprovalDate>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<ApprovalDate>
	{
		public Validator()
		{
			RuleFor(x => x._value)
				.NotEmpty()
				.GreaterThan(new DateTime(1900, 1, 1))
				.LessThan(new DateTime(2100, 1, 1))
				.WithName(nameof(ApprovalDate));
		}
	}
}
