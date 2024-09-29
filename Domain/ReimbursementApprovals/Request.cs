using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals;

public record Request
{
	public static Optional<Unfinished> Create(string patientId)
		=> Unfinished.Create(patientId);
}