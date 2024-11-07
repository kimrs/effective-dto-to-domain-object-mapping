using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithDrugPrescription
	: IStrategy
{
	public bool For(Domain.Requests.Request domain)
		=> domain is ThatIsNotOpiate;

	public Optional<Request> ToDto(Domain.Requests.Request domain)
		=> domain is ThatIsNotOpiate request
			? new Request(
				PatientId: request.PatientId,
				Name: null,
				ItemNumber: request.ItemNumber.ToMachingeReadable(),
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}