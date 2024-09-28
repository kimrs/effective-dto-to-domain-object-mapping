using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using FluentValidation.Results;
using Functional;

namespace Eik.ReimbursementApprovals;

public class Adapter()
	: IAdapter
{
	public Optional<Response> Handle(Request request)
	{
		// return new Response();
		// return new NotImplementedException();
		return new ValidationFailure("Hei", "padeg");
	}
}