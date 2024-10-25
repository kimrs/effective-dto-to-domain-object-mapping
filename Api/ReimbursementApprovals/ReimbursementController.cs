using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.ReimbursementApprovals.Requests;
using FluentValidation.Results;
using Functional;
using Functional.Operations;
using Microsoft.AspNetCore.Mvc;
using Request = DrugDispenser.Domain.ReimbursementApprovals.Requests.Request;

namespace DrugDispenser.ReimbursementApprovals;

[ApiController]
[Route("Reimbursement")]
public class ReimbursementController(IAdapter adapter)
    : ControllerBase
{
    private Task<ActionResult> Handle(Request request)
        => adapter
            .Handle(request)
            .MatchAsync<Response, ActionResult>(
                success: Ok,
                invalid: _ => Problem(),
                exception: _ => Problem());
            
    [HttpPost("Approval")]
    public async Task<ActionResult> Approve([FromBody] Requests.Request dto)
    {
        return await dto.ToDomain()
            .Match<Request, Task<ActionResult>>(
                success: Handle,
                invalid: x => Task.FromResult<ActionResult>(BadRequest(x)),
                exception: _ => Task.FromResult<ActionResult>(Problem()));
    }
}