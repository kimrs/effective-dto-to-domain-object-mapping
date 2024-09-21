using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.ReimbursementApprovals.Requests;
using FluentValidation;
using Functional;
using Functional.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DrugDispenser.ReimbursementApprovals;

public class Validator : AbstractValidator<Requests.Request>
{
    public Validator()
    {
        RuleFor(x => x.Code)
            .NotNull();
        RuleFor(x => x.Code!.CodingSystem)
            .Must(x => x is "ICD-10" or "ICD-11")
            .When(x => x.Code is not null);
        RuleFor(x => x.Code!.Id)
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(6)
            .Matches("^[A-Za-z]{2}\\.[0-9]{1,5}$")
            .WithMessage("Kode må starte på to tall etterfulgt av punktum og et tall")
            .When(x => x.Code is not null);

        RuleFor(x => x.IdNumber)
            .NotNull();
        RuleFor(x => x.IdNumber!.Number)
            .NotNull()
            .Length(11)
            .When(x => x.IdNumber is not null);
        RuleFor(x => x.IdNumber!.Type)
            .Must(x => x is "D-Nummer" or "Fødselsnummer")
            .WithMessage("Må være enten D-Nummer eller Fødselsnummer")
            .When(x => x.IdNumber is not null);
    }
}

[ApiController]
[Route("Dispenser")]
public class ReimbursementController(IAdapter adapter)
    : ControllerBase
{
    [HttpPost("Dispense")]
    public IActionResult Dispense([FromBody] Requests.Request dto)
        => dto.ToDomain()
            .Bind(adapter.Handle) switch
            {
                Completional<Response> c => Ok(c.Value),
                Validational<Response> v => BadRequest(v.Failures),
                Exceptional<Response> e => throw e.Exception,
                _ => throw new Exception("Jeg liker ikke exceptions")
            };
}