using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record Request
{
	public static Optional<Unfinished> Create(string patientId)
		=> Unfinished.Create(patientId);
}