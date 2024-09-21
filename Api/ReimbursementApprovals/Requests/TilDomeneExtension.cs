using Functional;

namespace DrugDispenser.ReimbursementApprovals.Requests;

public static class TilDomeneExtension
{
	public static Optional<Domain.ReimbursementApprovals.Request> ToDomain(this Request dto)
		=> new Domain.ReimbursementApprovals.Request ();
}