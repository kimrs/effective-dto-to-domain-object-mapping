using Functional;

namespace Eik.Requests.Strategies;

public interface IStrategy
{
	bool For(Domain.Request domain);

	public Optional<Request> ToDto(Domain.Request domain);
}