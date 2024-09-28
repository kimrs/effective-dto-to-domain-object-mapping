using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals;

public interface IAdapter
{
	Task<Optional<Response>> Handle(Request request);
	Optional<Task<Response>> AHandle(Request request);
}