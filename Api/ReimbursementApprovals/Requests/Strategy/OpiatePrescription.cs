using DrugDispenser.Domain;
using DrugDispenser.Domain.Drug;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategy;

public class OpiatePrescription
	: IStrategy
{
	public bool StrategyFor(Request r)
		=> r is { RetailPrescription: null, DrugPrescription.PrescriberId: not null };

	public Optional<D.Request> ToDomain(Request dto)
		=> dto.Combine(
			x => PatientId.Create(x.PatientId),
			x => ItemNumber.Create(x.DrugPrescription!.ItemNumber),
			x => PrescriberId.Create(x.DrugPrescription!.PrescriberId)
		).Bind<(PatientId patientId, ItemNumber itemNumber, PrescriberId prescriberId), D.Request>(
			x => D.Request
				.Create(x.patientId)
				.WithDrug(x.itemNumber)
				.ThatIsOpiate(x.prescriberId)
				.Bind<ThatIsOpiate, D.Request>(x => x)
		);
}