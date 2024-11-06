using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithDrugPrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsNotOpiate;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsNotOpiate request
			? new Request(
				PatientId: request.PatientId,
				ApprovalType: null,
				ItemNumber: request.ItemNumber,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}