using DrugDispenser.Domain;
using Functional;
using Functional.Operations;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal class ApprovedForMedicalNutrition
    : IStrategy
{
    public bool For(Response dto)
        => dto is {EikApi.Approval.IsMedicalNutrition: true};

    public Result<Domain.Response> ToDomain(Response dto)
        => ToDomain(dto.EikApi.Approval);

    private Result<Domain.Response> ToDomain(Approval dto)
        => ApprovalDate.Create(dto.ValidFrom!.Value)
            .Then<ApprovalDate, Domain.Response>(
                x => new Domain.Responses.ApprovedForMedicalNutrition(x)
            );
}