using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public interface IStrategy
{
	bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain);

	Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain);
}