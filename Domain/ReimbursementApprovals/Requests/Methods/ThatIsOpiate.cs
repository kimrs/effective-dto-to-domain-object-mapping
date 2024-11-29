using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record ThatIsOpiate(
	PatientId PatientId,
	ItemNumber ItemNumber,
	PrescriberId PrescriberId
) : Request;

public static partial class E
{
	public static Result<ThatIsOpiate> ThatIsOpiate(
		this Result<WithDrug> request,
		PrescriberId prescriberId
	) => request.Then<WithDrug, ThatIsOpiate>(
		x => new ThatIsOpiate(
			x.PatientId,
			x.ItemNumber,
			prescriberId));
}