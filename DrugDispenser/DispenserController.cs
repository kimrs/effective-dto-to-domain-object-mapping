using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DrugDispenser;

public record Code(string? CodingSystem, string? Id);
public record IdNumber(string? Number, string? Type);
public record Request(IdNumber? IdNumber, Code? Code);

public class Validator : AbstractValidator<Request>
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
public class DispenserController : ControllerBase
{
    [HttpPost("Dispense")]
    public IActionResult Dispense([FromBody] Request request)
    {
        var validationResult = new Validator().Validate(request);
        
        return validationResult.IsValid
            ? Ok($"hello {request.IdNumber!.Number}")
            : BadRequest(string.Join(Environment.NewLine, validationResult.Errors));
    }
}