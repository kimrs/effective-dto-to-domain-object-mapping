
using Functional;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal interface IStrategy
{
    bool For(Response dto);
    
    Optional<Domain.Response> ToDomain(Response dto);
}