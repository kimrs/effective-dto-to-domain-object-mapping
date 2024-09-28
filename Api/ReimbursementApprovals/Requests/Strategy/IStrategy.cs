using Functional;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategy;

public interface IStrategy
{
	bool StrategyFor(Request r);
	Optional<D.Request> ToDomain(Request dto);
}