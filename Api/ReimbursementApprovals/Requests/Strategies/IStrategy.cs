using Functional;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public interface IStrategy
{
	bool For(Request r);
	Optional<Domain.ReimbursementApprovals.Request> ToDomain(Request dto);
}