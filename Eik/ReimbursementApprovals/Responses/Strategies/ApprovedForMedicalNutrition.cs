using DrugDispenser.Domain;
using Functional;
using Functional.Operations;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal class ApprovedForMedicalNutrition
    : IStrategy
{
    public bool For(Response dto)
        => dto is {EikApi.Approval.IsMedicalNutrition: true};

    public Optional<Domain.Response> ToDomain(Response dto)
        => ToDomain(dto.EikApi.Approval);

    private Optional<Domain.Response> ToDomain(Approval dto)
        => ApprovalDate.Create(dto.ValidFrom!.Value)
            .Bind<ApprovalDate, Domain.Response>(
                x => new Domain.Responses.ApprovedForMedicalNutrition(x)
            );
}