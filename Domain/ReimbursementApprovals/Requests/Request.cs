using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public abstract record Request
{
	public static Optional<Unfinished> Create(PatientId patientId)
		=> Unfinished.Create(patientId);
}