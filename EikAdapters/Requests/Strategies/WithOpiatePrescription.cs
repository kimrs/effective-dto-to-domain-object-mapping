using Functional;

namespace Eik.Requests.Strategies;

public class WithOpiatePrescription
	: IStrategy
{
	public bool For(Domain.Request domain)
		=> domain is Domain.ThatIsOpiate;

	public Optional<Request> ToDto(Domain.Request domain)
		=> domain is Domain.ThatIsOpiate thatIsOpiate
			? new Request(
				PatientId: thatIsOpiate.PatientId,
				ApprovalType: null,
				ItemNumber: thatIsOpiate.ItemNumber,
				PrescriberId: thatIsOpiate.PrescriberId
			) : new NotSupportedException(domain.GetType().FullName);
}