using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public interface IStrategy
{
	bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain);

	Result<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain);
}