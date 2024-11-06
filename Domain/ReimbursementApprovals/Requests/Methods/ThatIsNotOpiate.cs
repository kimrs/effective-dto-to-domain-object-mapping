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
    public static Optional<ThatIsNotOpiate> ThatIsNotOpiate(
        this Optional<WithDrug> request
    ) => request.Bind<WithDrug, ThatIsNotOpiate>(
        x => new ThatIsNotOpiate(
            x.PatientId,
            x.ItemNumber));
}