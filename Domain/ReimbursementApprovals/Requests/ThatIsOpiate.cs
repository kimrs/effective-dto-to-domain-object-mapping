
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record ThatIsOpiate(
	string PatientId,
	string ItemNumber,
	string PrescriberId
) : Request;

public static partial class E
{
	public static Optional<ThatIsOpiate> ThatIsOpiate(
		this Optional<WithDrug> request,
		string prescriberId
	) => request.Bind<WithDrug, ThatIsOpiate>(
		x => new ThatIsOpiate(
			x.PatientId,
			x.ItemNumber,
			prescriberId));
}