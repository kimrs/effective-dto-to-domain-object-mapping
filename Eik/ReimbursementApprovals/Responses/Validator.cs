using System.Collections.Immutable;
using FluentValidation;
using Functional;

namespace Eik.ReimbursementApprovals.Responses;

internal class Validator : AbstractValidator<Response>
{
    public Validator()
    {
        RuleFor(x => x.EikApi.Approval.ValidFrom)
            .NotEmpty()
            .When(x => x.EikApi.Approval.IsMedicalNutrition is true);

        RuleFor(x => x.EikApi.Approval.ReimbursementArticle)
            .NotEmpty()
            .When(x => x.EikApi.Approval.IsMedicalNutrition is false);
        
        RuleFor(x => x.EikApi.Approval.ReimbursementArticle.V)
            .NotEmpty()
            .When(x => x.EikApi.Approval.IsMedicalNutrition is false);

        RuleFor(x => x.EikApi.Approval.ReimbursementArticle.Dn)
            .NotEmpty()
            .When(x => x.EikApi.Approval.IsMedicalNutrition is false);
    }
}

internal static class E
{
    public static Optional<Response> Validate(
        this Response response
    )
    {
        var validationResult = new Validator()
            .Validate(response);

        return validationResult.IsValid
            ? response
            : validationResult.Errors;
    }
}