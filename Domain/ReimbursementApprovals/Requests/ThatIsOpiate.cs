
using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record ThatIsOpiate(
	PatientId PatientId,
	ItemNumber ItemNumber,
	PrescriberId PrescriberId
) : Request;

public static partial class E
{
	public static Optional<ThatIsOpiate> ThatIsOpiate(
		this Optional<WithDrug> request,
		PrescriberId prescriberId
	) => request.Bind<WithDrug, ThatIsOpiate>(
		x => new ThatIsOpiate(
			x.PatientId,
			x.ItemNumber,
			prescriberId));
}