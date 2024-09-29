using Functional;
using Functional.Operations;
using Drugs = DrugDispenser.Domain.Drugs;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal class ApprovedForMedicalNutrition
    : IStrategy
{
    public bool For(Response dto)
        => dto is {EikApi.Approval.IsMedicalNutrition: true};

    public Optional<Domain.Response> ToDomain(Response dto)
        => ToDomain(dto.EikApi.Approval);

    private Optional<Domain.Response> ToDomain(Approval dto)
        => dto.ValidFrom
            .ToDomain()
            .Bind<DateTime, Domain.Response>(
                x => new Domain.Responses.ApprovedForMedicalNutrition(x)
            );
}