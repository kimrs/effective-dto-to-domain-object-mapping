using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithOpiatePrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsOpiate;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsOpiate thatIsOpiate
			? new Request(
				PatientId: thatIsOpiate.PatientId,
				ApprovalType: null,
				ItemNumber: thatIsOpiate.ItemNumber,
				PrescriberId: thatIsOpiate.PrescriberId
			) : new NotSupportedException(domain.GetType().FullName);
}