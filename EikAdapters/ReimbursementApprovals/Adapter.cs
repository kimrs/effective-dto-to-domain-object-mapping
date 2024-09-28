using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using FluentValidation.Results;
using Functional;

namespace Eik.ReimbursementApprovals;

public class Adapter(HttpClient httpClient)
	: IAdapter
{
	public async Task<Optional<Response>> Handle(Request request)
	{
		using HttpResponseMessage response = await httpClient.PostAsync("d/d");
		// return new Response();
		// return new NotImplementedException();
		
		return new ValidationFailure("Hei", "padeg");
	}

	public Optional<Task<Response>> AHandle(Request request)
	{
		
	}
}