using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithDrugPrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.WithDrug;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.WithDrug withDrug
			? new Request(
				PatientId: withDrug.PatientId,
				ApprovalType: null,
				ItemNumber: withDrug.ItemNumber,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}