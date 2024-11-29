using DrugDispenser.Domain.Drugs;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record WithDrug(
	PatientId PatientId,
	ItemNumber ItemNumber) : Unfinished;

public static partial class E
{
	public static Result<WithDrug> WithDrug(
		this Result<Create> request,
		ItemNumber itemNumber
	) => request.Then<Create, WithDrug>(
		x => new WithDrug(
			x.PatientId,
			itemNumber));
}
