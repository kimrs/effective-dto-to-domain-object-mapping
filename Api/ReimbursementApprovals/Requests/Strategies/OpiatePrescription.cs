using DrugDispenser.Domain;
using DrugDispenser.Domain.Drug;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public class OpiatePrescription
	: IStrategy
{
	public bool For(Request r)
		=> r is { RetailPrescription: null, DrugPrescription.PrescriberId: not null };

	public Optional<Domain.ReimbursementApprovals.Request> ToDomain(Request dto)
		=> dto.Combine(
			x => PatientId.Create(x.PatientId),
			x => ItemNumber.Create(x.DrugPrescription!.ItemNumber),
			x => PrescriberId.Create(x.DrugPrescription!.PrescriberId)
		).Bind<(PatientId patientId, ItemNumber itemNumber, PrescriberId prescriberId), Domain.ReimbursementApprovals.Request>(
			x => Domain.ReimbursementApprovals.Request
				.Create(x.patientId)
				.WithDrug(x.itemNumber)
				.ThatIsOpiate(x.prescriberId)
				.Bind<ThatIsOpiate, Domain.ReimbursementApprovals.Request>(x => x)
		);
}