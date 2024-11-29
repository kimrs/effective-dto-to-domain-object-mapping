
using Functional;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal interface IStrategy
{
    bool For(Response dto);
    
    Result<Domain.Response> ToDomain(Response dto);
}