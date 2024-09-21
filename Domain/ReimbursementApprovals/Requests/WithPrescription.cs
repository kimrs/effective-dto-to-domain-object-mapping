using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record WithPrescription(string PatientId, string ItemNumber) : Request;

public static partial class E
{
	public static Optional<WithPrescription> WithPrescription(
		this Unfinished request,
		string itemNumber
	) => new WithPrescription(request.PatientId, itemNumber);
}
