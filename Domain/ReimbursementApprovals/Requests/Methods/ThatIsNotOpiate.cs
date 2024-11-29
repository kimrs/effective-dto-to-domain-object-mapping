using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record ThatIsNotOpiate(
    PatientId PatientId,
    ItemNumber ItemNumber
) : Request;

public static partial class E
{
    public static Result<ThatIsNotOpiate> ThatIsNotOpiate(
        this Result<WithDrug> request
    ) => request.Then<WithDrug, ThatIsNotOpiate>(
        x => new ThatIsNotOpiate(
            x.PatientId,
            x.ItemNumber));
}