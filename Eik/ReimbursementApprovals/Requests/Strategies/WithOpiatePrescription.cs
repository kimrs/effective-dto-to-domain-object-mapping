using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithOpiatePrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsOpiate;

	public Result<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is ThatIsOpiate thatIsOpiate
			? new Request(
				PatientId: thatIsOpiate.PatientId,
				Name: null,
				ItemNumber: $"{thatIsOpiate.ItemNumber:M}",
				PrescriberId: thatIsOpiate.PrescriberId
			) : new NotSupportedException(domain.GetType().FullName);
}