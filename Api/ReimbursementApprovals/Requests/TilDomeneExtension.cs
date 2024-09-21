using Functional;

namespace DrugDispenser.ReimbursementApprovals.Requests;

public static class TilDomeneExtension
{
	public static Optional<Domain.ReimbursementApprovals.Requests.Request> ToDomain(this Request dto)
		=> new Domain.ReimbursementApprovals.Requests.Request ();
}