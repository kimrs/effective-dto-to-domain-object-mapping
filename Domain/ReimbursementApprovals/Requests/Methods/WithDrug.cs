using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record WithDrug(
	PatientId PatientId,
	ItemNumber ItemNumber);

public static partial class E
{
	public static Optional<WithDrug> WithDrug(
		this Optional<Create> request,
		ItemNumber itemNumber
	) => request.Bind<Create, WithDrug>(
		x => new WithDrug(
			x.PatientId,
			itemNumber));
}
