using DrugDispenser.Domain.ReimbursementApprovals;
using Functional;

namespace Eik.ReimbursementApprovals;

public class Adapter
	: IAdapter
{
	public Optional<Response> Handle(Request request)
	{
		return new Response();
		// return new NotImplementedException();
		// return (Validational<Response>) new ValidationFailure("Hei", "padeg");
	}
}