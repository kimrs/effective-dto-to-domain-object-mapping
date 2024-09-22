using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record WithDrug(string PatientId, string ItemNumber) : Request;

public static partial class E
{
	public static Optional<WithDrug> WithDrug(
		this Optional<Unfinished> request,
		string itemNumber
	) => request.Bind<Unfinished, WithDrug>(
		x => new WithDrug(
			x.PatientId,
			itemNumber));
}
