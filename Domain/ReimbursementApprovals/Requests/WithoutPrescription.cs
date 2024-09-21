using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record WithoutPrescription(string PatientId, string ApprovalType) : Request;

public static partial class E
{
	public static Optional<WithoutPrescription> WithoutPrescription(
		this Unfinished unfinished,
		string applicationType
	) => new WithoutPrescription(unfinished.PatientId, applicationType);
}