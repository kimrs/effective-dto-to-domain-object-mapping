using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.ReimbursementApprovals.Requests;
using Functional;
using Functional.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DrugDispenser.ReimbursementApprovals;

[ApiController]
[Route("Reimbursement")]
public class ReimbursementController(IAdapter adapter)
    : ControllerBase
{
    [HttpPost("Approval")]
    public IActionResult Dispense([FromBody] Request dto)
        => dto.ToDomain()
            .Bind(adapter.Handle) switch
            {
                Completional<Response> c => Ok(c.Value),
                Validational<Response> v => BadRequest(v.Failures),
                Exceptional<Response> e => throw e.Exception,
                _ => throw new Exception("Jeg liker ikke exceptions")
            };
}