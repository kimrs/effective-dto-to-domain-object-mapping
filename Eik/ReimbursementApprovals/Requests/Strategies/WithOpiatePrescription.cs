using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithOpiatePrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.ThatIsOpiate;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.ThatIsOpiate thatIsOpiate
			? new Request(
				PatientId: thatIsOpiate.PatientId,
				ApprovalType: null,
				ItemNumber: thatIsOpiate.ItemNumber,
				PrescriberId: thatIsOpiate.PrescriberId
			) : new NotSupportedException(domain.GetType().FullName);
}