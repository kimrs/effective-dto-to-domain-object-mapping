using Functional;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public interface IStrategy
{
	bool For(Request r);
	Optional<D.Request> ToDomain(Request dto);
}