using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Responses;
using DrugDispenser.ReimbursementApprovals.Requests;
using FluentValidation.Results;
using Functional;
using Functional.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DrugDispenser.ReimbursementApprovals;

[ApiController]
[Route("Reimbursement")]
public class ReimbursementController(IAdapter adapter)
    : ControllerBase
{
    private Task<ActionResult> Handle(Domain.ReimbursementApprovals.Requests.Request request)
        => adapter
            .Handle(request)
            .MatchAsync<Response, ActionResult>(
                success: Ok,
                invalid: _ => Problem(),
                exception: _ => Problem());
            
    [HttpPost("Approval")]
    public async Task<ActionResult> Approve([FromBody] Request dto)
    {
        return await dto.ToDomain()
            .Match<Domain.ReimbursementApprovals.Requests.Request, Task<ActionResult>>(
                success: Handle,
                invalid: x => Task.FromResult<ActionResult>(BadRequest(x)),
                exception: _ => Task.FromResult<ActionResult>(Problem()));
    }
}