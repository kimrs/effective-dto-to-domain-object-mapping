using DrugDispenser.Domain;
using Functional;

namespace Eik.Requests.Strategies;

public class WithDrugPrescription
	: IStrategy
{
	public bool For(Domain.Request domain)
		=> domain is Domain.WithDrug;

	public Optional<Request> ToDto(Domain.Request domain)
		=> domain is Domain.WithDrug withDrug
			? new Request(
				PatientId: withDrug.PatientId,
				ApprovalType: null,
				ItemNumber: withDrug.ItemNumber,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}