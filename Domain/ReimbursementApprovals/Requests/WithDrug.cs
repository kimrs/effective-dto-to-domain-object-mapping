using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record WithDrug(
	PatientId PatientId,
	ItemNumber ItemNumber) : Request;

public static partial class E
{
	public static Optional<WithDrug> WithDrug(
		this Optional<Unfinished> request,
		ItemNumber itemNumber
	) => request.Bind<Unfinished, WithDrug>(
		x => new WithDrug(
			x.PatientId,
			itemNumber));
}
