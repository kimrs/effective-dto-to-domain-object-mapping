using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals;

public interface IAdapter
{
	Task<Result<Response>> Handle(Request request);
}