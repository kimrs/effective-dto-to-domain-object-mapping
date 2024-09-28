using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.ReimbursementApprovals.Responses;
using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals;

public interface IAdapter
{
	Task<Optional<Response>> Handle(Request request);
}