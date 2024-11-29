using DrugDispenser.Domain;
using DrugDispenser.Domain.Drugs;
using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public class OpiatePrescription
	: IStrategy
{
	public bool For(Request r)
		=> r is { RetailPrescription: null, DrugPrescription.PrescriberId: not null };

	public Result<D.Request> ToDomain(Request dto)
		=> dto.Combine(
			x => PatientId.Create(x.PatientId),
			x => ItemNumber.Create(x.DrugPrescription!.ItemNumber!),
			x => PrescriberId.Create(x.DrugPrescription!.PrescriberId!)
		).Then<(PatientId patientId, ItemNumber itemNumber, PrescriberId prescriberId), D.Request>(
			x => D.Request
				.Create(x.patientId)
				.WithDrug(x.itemNumber)
				.ThatIsOpiate(x.prescriberId)
				.Then<ThatIsOpiate, D.Request>(x => x)
		);
}