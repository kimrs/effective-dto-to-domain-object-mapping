using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public interface IStrategy
{
	bool For(Domain.Request domain);

	Optional<Request> ToDto(Domain.Request domain);
}