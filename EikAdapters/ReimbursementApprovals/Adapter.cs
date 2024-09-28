using DrugDispenser.Domain.ReimbursementApprovals;
using Eik.Requests;
using FluentValidation.Results;
using Functional;
using Functional.Operations;
using Request = DrugDispenser.Domain.ReimbursementApprovals.Requests.Request;
using Response = DrugDispenser.Domain.ReimbursementApprovals.Responses.Response;

namespace Eik.ReimbursementApprovals;

public class Adapter(HttpClient httpClient)
	: IAdapter
{
	public Task<Optional<Response>> Handle(Request request)
	{
		// request.ToDto().Bind(
		// 	x => httpClient.PostAsync("https://localhost:5098", x)
		// );
		// return new Response();
		// return new NotImplementedException();
		
		return Task.FromResult<Optional<Response>>(new ValidationFailure("Hei", "padeg"));
	}
}